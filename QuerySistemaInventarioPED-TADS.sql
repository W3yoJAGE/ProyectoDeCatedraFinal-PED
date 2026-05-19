CREATE DATABASE SistemaInventarioPed;
GO

USE SistemaInventarioPed;
GO

-- =========================
-- TABLA CATEGORIAS
-- =========================
CREATE TABLE Categorias (
    ID_Categoria INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL UNIQUE
);

-- =========================
-- TABLA PRODUCTOS
-- =========================
CREATE TABLE Productos (
    ID_Producto INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(50) NOT NULL UNIQUE,
    Nombre VARCHAR(150) NOT NULL,
    ID_Categoria INT NOT NULL,
    Precio DECIMAL(10,2) NOT NULL CHECK (Precio >= 0),
    Stock INT NOT NULL CHECK (Stock >= 0),
    RutaImagen VARCHAR(300),
    Activo BIT NOT NULL DEFAULT 1,

    CONSTRAINT FK_Productos_Categorias
    FOREIGN KEY (ID_Categoria)
    REFERENCES Categorias(ID_Categoria)
    ON UPDATE CASCADE
);

-- =========================
-- TABLA OFERTAS
-- =========================
CREATE TABLE Ofertas (
    ID_Oferta INT IDENTITY(1,1) PRIMARY KEY,
    ID_Producto INT NOT NULL,
    PorcentajeDescuento INT NOT NULL
        CHECK (PorcentajeDescuento BETWEEN 1 AND 100),
    Descripcion VARCHAR(250),
    Prioridad INT NOT NULL CHECK (Prioridad >= 0),
    Activa BIT NOT NULL DEFAULT 1,

    CONSTRAINT FK_Ofertas_Productos
    FOREIGN KEY (ID_Producto)
    REFERENCES Productos(ID_Producto)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

-- =========================
-- TABLA VENTAS
-- =========================
CREATE TABLE Ventas (
    ID_Venta INT IDENTITY(1,1) PRIMARY KEY,
    FechaHora DATETIME NOT NULL DEFAULT GETDATE(),
    Total DECIMAL(10,2) NOT NULL CHECK (Total >= 0)
);

-- =========================
-- TABLA DETALLE VENTAS
-- =========================
CREATE TABLE DetalleVentas (
    ID_DetalleVenta INT IDENTITY(1,1) PRIMARY KEY,
    ID_Venta INT NOT NULL,
    ID_Producto INT NOT NULL,
    Cantidad INT NOT NULL CHECK (Cantidad > 0),
    PrecioUnitarioVenta DECIMAL(10,2) NOT NULL
        CHECK (PrecioUnitarioVenta >= 0),

    Subtotal AS (Cantidad * PrecioUnitarioVenta) PERSISTED,

    CONSTRAINT FK_DetalleVentas_Ventas
    FOREIGN KEY (ID_Venta)
    REFERENCES Ventas(ID_Venta)
    ON DELETE CASCADE,

    CONSTRAINT FK_DetalleVentas_Productos
    FOREIGN KEY (ID_Producto)
    REFERENCES Productos(ID_Producto)
);

-- =========================
-- INDICES
-- =========================
CREATE INDEX IX_Productos_Codigo
ON Productos(Codigo);

CREATE INDEX IX_Productos_Nombre
ON Productos(Nombre);

-- =========================
-- VISTA CATALOGO
-- =========================
go
CREATE VIEW vw_CatalogoProductos AS
SELECT
    p.ID_Producto,
    p.Codigo,
    p.Nombre,
    c.Nombre AS Categoria,
    p.Precio AS PrecioOriginal,
    o.PorcentajeDescuento,

    CAST(
        p.Precio -
        (p.Precio * ISNULL(o.PorcentajeDescuento,0) / 100.0)
        AS DECIMAL(10,2)
    ) AS PrecioFinal,

    o.Descripcion AS OfertaDescripcion,
    o.Prioridad,
    p.Stock,
    p.RutaImagen
FROM Productos p
INNER JOIN Categorias c
    ON p.ID_Categoria = c.ID_Categoria
LEFT JOIN Ofertas o
    ON p.ID_Producto = o.ID_Producto
    AND o.Activa = 1;
GO
INSERT INTO Categorias (Nombre)
VALUES
('Electrónica'),
('Alimentos'),
('Hogar'),
('Belleza'),
('Papelería');

GO

INSERT INTO Productos
(
    Codigo,
    Nombre,
    ID_Categoria,
    Precio,
    Stock,
    RutaImagen,
    Activo
)
VALUES
(
    'PRD-001',
    'Television',
    1,
    499.99,
    15,
    'https://upload.wikimedia.org/wikipedia/commons/3/3f/Fronalpstock_big.jpg',
    1
);

go


CREATE UNIQUE INDEX UX_OfertaActiva_PorProducto 
ON Ofertas(ID_Producto) 
WHERE Activa = 1;

go