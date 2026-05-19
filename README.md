# 🏪 Sistema de Inventario — Cátedra PED

Sistema de escritorio desarrollado en **C# con Windows Forms** para la gestión de inventario, ofertas y punto de venta. Proyecto de Cátedra PED — Mayo 2026.

---

## 📋 Tabla de Contenidos

- [Descripción General](#descripción-general)
- [Tecnologías](#tecnologías)
- [Estructura del Proyecto](#estructura-del-proyecto)
- [Módulos y Funcionalidades](#módulos-y-funcionalidades)
  - [Dashboard Principal](#-dashboard-principal)
  - [Inventario](#-inventario)
  - [Agregar Producto](#-agregar-producto)
  - [Ofertas](#-ofertas)
  - [Terminal Punto de Venta](#-terminal-punto-de-venta)
  - [Vista del Cliente](#-vista-del-cliente)
- [Estructuras de Datos](#estructuras-de-datos)
- [Modelo de Base de Datos](#modelo-de-base-de-datos)
- [Clases Auxiliares](#clases-auxiliares)
- [Instalación y Ejecución](#instalación-y-ejecución)

---

## Descripción General

Aplicación de escritorio pensada para pequeños negocios que necesitan:

- Administrar su catálogo de productos con altas, modificaciones y bajas lógicas.
- Gestionar descuentos y ofertas con sistema de prioridades.
- Registrar ventas desde una terminal de punto de venta.
- Mostrar un catálogo visual ordenado por relevancia de ofertas para los clientes.

El sistema usa **Entity Framework 6** en modo Database-First sobre **SQL Server**, y aplica estructuras de datos como **búsqueda binaria** y **Max-Heap** como núcleo algorítmico del proyecto.

---

## Tecnologías

| Tecnología | Versión | Uso |
|---|---|---|
| C# | .NET Framework 4.8 | Lenguaje principal |
| Windows Forms | .NET 4.8 | Interfaz gráfica |
| Entity Framework | 6.2.0 | ORM — acceso a base de datos |
| SQL Server | LocalDB / Express | Base de datos relacional |
| GDI+ | Integrado en .NET | Estilos visuales personalizados (bordes redondeados) |

---

## Estructura del Proyecto

```
ProyectoCatedraPED-SistemaInventario/
│
├── Program.cs                        # Punto de entrada → lanza PantallaDashBoard
│
├── Forms/
│   ├── Index.cs / .Designer.cs       # Dashboard principal (shell de navegación)
│   ├── Inventario.cs / .Designer.cs  # Gestión del catálogo de productos
│   ├── AgregarProducto.cs            # Formulario modal para registrar productos
│   ├── ModificarProducto.cs            # Formulario para modificar productos
│   ├── OfertasPantalla.cs            # Creación y jerarquía de ofertas
│   ├── TerminalPV.cs                 # Terminal punto de venta (POS)
│   └── VistaUsuario.cs               # Catálogo visual para el cliente
│
├── CartaDeProducto.cs                # UserControl — tarjeta visual de producto
│
├── Clases/
│   ├── Producto.cs                   # DTO de producto para la vista cliente
│   ├── ProductoBusqueda.cs           # DTO para búsqueda binaria en inventario
│   ├── OfertaHeap.cs                 # Nodo del Max-Heap de ofertas
│   ├── MaxHeapOfertas.cs             # Implementación del Max-Heap
│   ├── Validaciones.cs               # Validaciones reutilizables para formularios
│   └── RedondeadoDeFormularioYBotones.cs  # Utilidades de estilo visual
│
└── Modelo/                           # Entidades generadas por Entity Framework
    ├── Model1.Context.cs             # DbContext → SistemaInventarioPedEntities
    ├── Productos.cs
    ├── Categorias.cs
    ├── Ofertas.cs
    ├── Ventas.cs
    ├── DetalleVentas.cs
    └── vw_CatalogoProductos.cs       # Vista SQL con precios y ofertas combinados
```

---

## Módulos y Funcionalidades

### 🖥️ Dashboard Principal

**Archivo:** `Forms/Index.cs` — Clase: `PantallaDashBoard`

Es el formulario raíz de la aplicación. Actúa como **shell de navegación**: contiene una barra lateral con cuatro botones de menú y un panel central donde se incrustan los demás módulos sin abrir ventanas nuevas.

**Funcionalidades:**
- Navegación entre módulos mediante botones con iconos emoji en la barra lateral.
- Los formularios hijos se cargan dentro del panel con `TopLevel = false` y `Dock = Fill`, sin barra de título propia.
- El botón activo cambia de color para indicar la sección actual.
- Efectos visuales en los botones del menú: hover cambia el texto a verde, leave lo regresa al color original.
- La ventana es **arrastrable** desde la barra superior usando APIs nativas de Windows (`ReleaseCapture` + `SendMessage`).
- Botón para alternar entre estado Normal y Maximizado; reaplica automáticamente el redondeo de esquinas.
- Botón de cierre que termina el proceso con `Environment.Exit(0)`.
- Todos los formularios y botones tienen **esquinas redondeadas** aplicadas con GDI+.

---

### 📦 Inventario

**Archivo:** `Forms/Inventario.cs` — Clase: `Inventario`

Módulo de administración completa del catálogo de productos.

**Funcionalidades:**

**Visualización:**
- Tabla principal (DataGridView estilizado) con todos los productos: Código, Nombre, Precio, Stock y Estado (`Activo` / `Inactivo`).
- Los productos se cargan ordenados alfabéticamente por nombre.

**Búsqueda:**
- Campo de texto con carga dinámica: al escribir, recarga y filtra la tabla en tiempo real.
- Botón **"Búsqueda Binaria"**: ejecuta búsqueda binaria sobre la lista ordenada por nombre. Muestra solo el producto encontrado o un mensaje si no existe.

**Gestión:**
- Botón **"Agregar Producto"**: abre el formulario `AgregarProducto` como ventana modal.
- Botón **"Modificar Producto"**: permite editar los datos del producto seleccionado en la tabla (nombre, precio, stock, categoría, imagen).
- Botón **"Eliminar Producto"**: realiza una **baja lógica** (establece `Activo = false` en la base de datos), sin eliminar el registro físicamente. Muestra confirmación al completarse.

---

### ➕ Agregar Producto

**Archivo:** `Forms/AgregarProducto.cs` — Clase: `AgregarProducto`

Formulario modal que se abre desde el módulo de Inventario para registrar nuevos productos.

**Funcionalidades:**
- **Código autogenerado**: al abrir el formulario, consulta el último ID en la base de datos y genera automáticamente un código en formato `PRD-001`, `PRD-002`, etc.
- Campos con **texto placeholder** en gris que desaparecen al hacer foco (Nombre, Precio, Cantidad, URL Imagen).
- **ComboBox de Categoría** cargado dinámicamente desde la base de datos.
- Botón **"Preview"**: descarga la imagen desde la URL ingresada (vía `HttpWebRequest` con TLS 1.2) y la previsualiza en un `PictureBox` antes de guardar.
- **Validaciones completas** antes de guardar:
  - Ningún campo puede tener el texto placeholder.
  - El precio debe ser un decimal válido.
  - La cantidad debe ser un entero válido.
- Al guardar: inserta el producto en la base de datos con `Activo = true` y limpia el formulario para un nuevo registro.
- Botón **"Volver"** para cerrar sin guardar.
- La ventana es arrastrable desde su barra superior.

---

### 🏷️ Ofertas

**Archivo:** `Forms/OfertasPantalla.cs` — Clase: `OfertasPantalla`

Módulo para crear y visualizar descuentos activos sobre los productos.

**Funcionalidades:**

**Crear oferta:**
- Selector de producto (ComboBox) que muestra `Nombre (Código)` de todos los productos activos.
- Campo para ingresar el **porcentaje de descuento** (%).
- Campo para una **descripción promocional** (ej: "Venta de Verano", "Outlet").
- La **prioridad** de la oferta se asigna automáticamente igual al porcentaje de descuento.
- Validación: producto seleccionado y descuento numérico válido.
- Botón **"Finalizar Transacción"** para guardar la oferta.

**Jerarquía de ofertas (DataGridView):**
- Muestra todas las ofertas activas cuyos productos también estén activos.
- Las ofertas se insertan en un **Max-Heap** y se extraen ordenadas de **mayor a menor prioridad**, garantizando que los mayores descuentos aparezcan siempre primero.
- **El botón de ofertas activas en la tabla funciona correctamente**: permite interactuar con la fila seleccionada para gestionar el estado de la oferta directamente desde el DataGridView.
- La tabla se recarga automáticamente cada vez que se crea una nueva oferta.

---

### 🛍️ Terminal Punto de Venta

**Archivo:** `Forms/TerminalPV.cs` — Clase: `TerminalPV`

Módulo POS (Point of Sale) para registrar ventas.

**Funcionalidades:**

**Búsqueda de productos:**
- Campo de búsqueda en tiempo real: filtra productos activos por nombre o código mientras se escribe.
- Muestra automáticamente el **precio con descuento** si el producto tiene una oferta activa (usando `vw_CatalogoProductos`), o el precio original si no la tiene.

**Carrito de compras:**
- **Doble clic sobre una fila** del resultado de búsqueda agrega el producto al carrito.
- El carrito se muestra en un DataGridView con: Nombre, Precio, Cantidad y Subtotal.
- Los productos se almacenan en una lista en memoria (`List<dynamic>`) durante la sesión.

**Finalizar venta:**
- Botón **"Finalizar Transacción"**: calcula el total sumando todos los subtotales del carrito.
- Registra una entrada en la tabla `Ventas` (fecha/hora + total).
- Registra un `DetalleVentas` por cada producto del carrito (ID producto, cantidad, precio unitario al momento de la venta).
- Limpia el carrito y recarga la tabla de ventas recientes al completar.

**Ventas recientes:**
- Panel lateral que muestra las **últimas 10 ventas** registradas (ID, Fecha/Hora, Total), ordenadas de más reciente a más antigua.

---

### 🏪 Vista del Cliente

**Archivo:** `Forms/VistaUsuario.cs` — Clase: `VistaUsuario`

Catálogo visual de productos orientado al cliente final.

**Funcionalidades:**

**Catálogo en tarjetas:**
- Cada producto se muestra como una `CartaDeProducto` (UserControl) con: imagen, categoría, nombre, precio original tachado, precio con descuento y descripción de la oferta.
- Las tarjetas se organizan en un `FlowLayoutPanel` que las acomoda automáticamente.
- Los productos se **ordenan de mayor a menor descuento** usando el **Max-Heap**: los productos con la mejor oferta siempre aparecen primero.
- Si un producto tiene múltiples ofertas activas, solo se muestra la de mayor prioridad.
- Solo se muestran productos con `Activo = true`.

**Filtros:**
- **Buscador en tiempo real**: filtra por nombre o código del producto mientras se escribe.
- **ComboBox de categoría**: filtra el catálogo por categoría. La opción "Todas" muestra el catálogo completo sin filtros.

**Tarjeta de producto (`CartaDeProducto`):**
- Control visual reutilizable con etiquetas para categoría, nombre, precio original, precio final, porcentaje de descuento (`-X%`) y descripción de la oferta.
- Carga la imagen del producto desde su URL; si falla la descarga, no muestra imagen sin interrumpir la interfaz.
- Etiqueta de "¡Últimas unidades!" disponible para productos con stock bajo.

---

## Estructuras de Datos

### Max-Heap de Ofertas (`MaxHeapOfertas`)

Implementación propia de un **montículo máximo** (Max-Heap) sobre `List<OfertaHeap>`. Garantiza que la oferta de mayor prioridad siempre esté en la raíz (índice 0).

| Operación | Método | Complejidad |
|---|---|---|
| Insertar | `Insertar(OfertaHeap)` | O(log n) |
| Extraer máximo | `ExtraerMaximo()` | O(log n) |
| Consultar máximo | `monticulo[0]` | O(1) |
| Ordenar todos | n extracciones | O(n log n) |

**Relaciones de índices:**
- Padre del nodo `i`: `(i - 1) / 2`
- Hijo izquierdo: `2 * i + 1`
- Hijo derecho: `2 * i + 2`

**Usos en el sistema:**
- **Pantalla de Ofertas**: ordena todas las ofertas activas de mayor a menor descuento en el DataGridView.
- **Vista del Cliente**: ordena las tarjetas del catálogo para que los productos con mayor descuento aparezcan primero.

### Búsqueda Binaria

Implementada en el módulo de **Inventario** sobre una lista de `ProductoBusqueda` ordenada alfabéticamente por nombre. Complejidad: **O(log n)**.

La lista se ordena previamente con LINQ (`OrderBy(p => p.Nombre)`) antes de aplicar el algoritmo, garantizando la precondición de la búsqueda binaria.

---

## Modelo de Base de Datos

El modelo es generado por **Entity Framework 6 Database-First**. El `DbContext` es `SistemaInventarioPedEntities`.

```
Categorias ──< Productos >──< Ofertas
                   │
                   └──< DetalleVentas >── Ventas

vw_CatalogoProductos  ← Vista SQL (solo lectura)
                         combina Productos + Ofertas
```

| Tabla / Vista | Descripción |
|---|---|
| `Categorias` | Grupos de productos (ID_Categoria, Nombre) |
| `Productos` | Catálogo completo con precio, stock, imagen y estado activo/inactivo |
| `Ofertas` | Descuentos por producto con porcentaje, descripción y prioridad |
| `Ventas` | Encabezado de cada transacción (fecha/hora, total) |
| `DetalleVentas` | Línea de detalle por producto vendido (cantidad, precio unitario, subtotal) |
| `vw_CatalogoProductos` | Vista SQL que combina producto con su mejor oferta activa |

---

## Clases Auxiliares

### `Validaciones` (estática)
Métodos de validación reutilizables para controles de formulario:
- `NoVacio(TextBox, string)` — campo obligatorio.
- `SoloLetras(TextBox, string)` — solo caracteres alfabéticos.
- `SoloNumeros(TextBox, string)` — solo dígitos numéricos válidos.
- `ComboSeleccionado(ComboBox, string)` — requiere selección activa.

### `RedondeadoDeFormularioYBotones` (estática)
Utilidades de estilo visual con GDI+:
- `RedondeoForm(Form)` — esquinas redondeadas en formularios (radio 30px).
- `RedondeoBtn(Control)` — esquinas redondeadas en botones y controles.
- `RedondeadoGroupBox(GroupBox)` — GroupBox con borde y texto personalizados.
- `FormatearDataGridView(DataGridView)` — estilos unificados: encabezado azul `#2B6CB0`, filas alternas, fuente Inter 9pt, selección azul claro, altura de fila 36px.

---

## Instalación y Ejecución

### Requisitos previos
- Visual Studio 2022 (Community o superior)
- .NET Framework 4.8
- SQL Server (LocalDB, Express o superior)

### Pasos

1. Clona el repositorio:
   ```bash
   git clone https://github.com/tu-usuario/ProyectoCatedraPED-SistemaInventario.git
   ```

2. Abre la solución en Visual Studio:
   ```
   ProyectoCatedraPED-SistemaInventario.sln
   ```

3. Configura la cadena de conexión en `App.config`:
   ```xml
   <connectionStrings>
     <add name="SistemaInventarioPedEntities"
          connectionString="metadata=res://...;
                            provider=System.Data.SqlClient;
                            provider connection string='data source=TU_SERVIDOR;
                            initial catalog=SistemaInventarioPed;
                            integrated security=True;'"
          providerName="System.Data.EntityClient" />
   </connectionStrings>
   ```

4. Asegúrate de que la base de datos SQL Server esté disponible con las tablas y la vista `vw_CatalogoProductos` creadas.

5. Compila y ejecuta (`F5`).

---

## Notas Adicionales

- La **eliminación de productos es lógica** (`Activo = false`), nunca se borra el registro físicamente de la base de datos.
- La prioridad de una oferta **se asigna automáticamente igual a su porcentaje de descuento**. Un descuento del 50% siempre tendrá mayor prioridad que uno del 20%.
- El código de producto se **autogenera** en formato `PRD-NNN` al abrir el formulario de alta.
- Las imágenes se cargan desde URLs externas; si la URL es inválida, el sistema continúa sin mostrar imagen.

---

*Proyecto desarrollado como parte de la Cátedra PED — Mayo 2026.*
