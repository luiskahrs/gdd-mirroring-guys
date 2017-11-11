USE [GD2C2017]
GO

-- Borramos toda la base por las dudas
IF EXISTS (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'MIRRORING_GUYS' AND  TABLE_NAME = '[MIRRORING_GUYS].[UsuarioRol]')
BEGIN
   DROP TABLE [MIRRORING_GUYS].[UsuarioRol]
END
GO

IF EXISTS (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'MIRRORING_GUYS' AND  TABLE_NAME = '[MIRRORING_GUYS].[FuncPorRol]')
BEGIN
   DROP TABLE [MIRRORING_GUYS].[FuncPorRol]
END
GO

IF EXISTS (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'MIRRORING_GUYS' AND  TABLE_NAME = '[MIRRORING_GUYS].[Funcionalidad]')
BEGIN
   DROP TABLE [MIRRORING_GUYS].[Funcionalidad]
END
GO

IF EXISTS (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'MIRRORING_GUYS' AND  TABLE_NAME = '[MIRRORING_GUYS].[Rol]')
BEGIN
   DROP TABLE [MIRRORING_GUYS].[Rol]
END
GO

IF EXISTS (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'MIRRORING_GUYS' AND  TABLE_NAME = '[MIRRORING_GUYS].[Usuario]')
BEGIN
   DROP TABLE [MIRRORING_GUYS].[Usuario]
END
GO

IF EXISTS (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'MIRRORING_GUYS' AND  TABLE_NAME = '[MIRRORING_GUYS].[Cliente]')
BEGIN
   DROP TABLE [MIRRORING_GUYS].[Cliente]
END
GO

IF EXISTS (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'MIRRORING_GUYS' AND  TABLE_NAME = '[MIRRORING_GUYS].[Devolucion]')
BEGIN
   DROP TABLE [MIRRORING_GUYS].[Devolucion]
END
GO

IF EXISTS (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'MIRRORING_GUYS' AND  TABLE_NAME = '[MIRRORING_GUYS].[Direccion]')
BEGIN
   DROP TABLE [MIRRORING_GUYS].[Direccion]
END
GO

IF EXISTS (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'MIRRORING_GUYS' AND  TABLE_NAME = '[MIRRORING_GUYS].[Empresa]')
BEGIN
   DROP TABLE [MIRRORING_GUYS].[Empresa]
END
GO

IF EXISTS (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'MIRRORING_GUYS' AND  TABLE_NAME = '[MIRRORING_GUYS].[Factura]')
BEGIN
   DROP TABLE [MIRRORING_GUYS].[Factura]
END
GO

IF EXISTS (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'MIRRORING_GUYS' AND  TABLE_NAME = '[MIRRORING_GUYS].[FormaPago]')
BEGIN
   DROP TABLE [MIRRORING_GUYS].[FormaPago]
END
GO

IF EXISTS (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'MIRRORING_GUYS' AND  TABLE_NAME = '[MIRRORING_GUYS].[HistoricoPago]')
BEGIN
   DROP TABLE [MIRRORING_GUYS].[HistoricoPago]
END
GO

IF EXISTS (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'MIRRORING_GUYS' AND  TABLE_NAME = '[MIRRORING_GUYS].[ItemFactura]')
BEGIN
   DROP TABLE [MIRRORING_GUYS].[ItemFactura]
END
GO

IF EXISTS (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'MIRRORING_GUYS' AND  TABLE_NAME = '[MIRRORING_GUYS].[Pago]')
BEGIN
   DROP TABLE [MIRRORING_GUYS].[Pago]
END
GO

IF EXISTS (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'MIRRORING_GUYS' AND  TABLE_NAME = '[MIRRORING_GUYS].[Rendicion]')
BEGIN
   DROP TABLE [MIRRORING_GUYS].[Rendicion]
END
GO

IF EXISTS (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'MIRRORING_GUYS' AND  TABLE_NAME = '[MIRRORING_GUYS].[Rubro]')
BEGIN
   DROP TABLE [MIRRORING_GUYS].[Rubro]
END
GO

IF EXISTS (SELECT COUNT(1) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'MIRRORING_GUYS' AND  TABLE_NAME = '[MIRRORING_GUYS].[Sucursal]')
BEGIN
   DROP TABLE [MIRRORING_GUYS].[Sucursal]
END
GO

IF EXISTS (SELECT COUNT(1) FROM sysobjects WHERE  id = object_id(N'[MIRRORING_GUYS].[Usuario_Login]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
	DROP PROCEDURE [MIRRORING_GUYS].[Usuario_Login]
END
GO

IF NOT EXISTS (select COUNT(1) from sys.database_principals where name = 'gd')
BEGIN
	CREATE USER [gd] FOR LOGIN [gd] WITH DEFAULT_SCHEMA=[dbo]
END
GO

IF (NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'MIRRORING_GUYS')) 
BEGIN
    EXEC ('CREATE SCHEMA [MIRRORING_GUYS] AUTHORIZATION [gd]')
END
GO

/****** Object:  Table [MIRRORING_GUYS].[Funcionalidad]    Script Date: 04/11/2017 18:35:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [MIRRORING_GUYS].[Funcionalidad](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[formulario] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [MIRRORING_GUYS].[FuncPorRol]    Script Date: 04/11/2017 18:35:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MIRRORING_GUYS].[FuncPorRol](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_func] [int] NOT NULL,
	[id_rol] [int] NOT NULL,
 CONSTRAINT [PK_FuncPorRol] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MIRRORING_GUYS].[Rol]    Script Date: 04/11/2017 18:35:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [MIRRORING_GUYS].[Rol](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[habilitado] BIT NOT NULL	DEFAULT(1)
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [MIRRORING_GUYS].[Usuario]    Script Date: 04/11/2017 18:35:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [MIRRORING_GUYS].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](20) NOT NULL UNIQUE,
	[password] [char](64) NOT NULL,
	[logins_fallidos] [tinyint] NOT NULL,
	[habilitado] [bit] NOT NULL
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [MIRRORING_GUYS].[UsuarioRol]    Script Date: 04/11/2017 18:35:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MIRRORING_GUYS].[UsuarioRol](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario] [int] NOT NULL,
	[id_rol] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioRol] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [MIRRORING_GUYS].[FuncPorRol]  WITH CHECK ADD  CONSTRAINT [FK_FuncPorRol_Func] FOREIGN KEY([id_func])
REFERENCES [MIRRORING_GUYS].[Funcionalidad] ([id])
GO
ALTER TABLE [MIRRORING_GUYS].[FuncPorRol] CHECK CONSTRAINT [FK_FuncPorRol_Func]
GO
ALTER TABLE [MIRRORING_GUYS].[FuncPorRol]  WITH CHECK ADD  CONSTRAINT [FK_FuncPorRol_Rol] FOREIGN KEY([id_rol])
REFERENCES [MIRRORING_GUYS].[Rol] ([id])
GO
ALTER TABLE [MIRRORING_GUYS].[FuncPorRol] CHECK CONSTRAINT [FK_FuncPorRol_Rol]
GO
ALTER TABLE [MIRRORING_GUYS].[UsuarioRol]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRol_Rol] FOREIGN KEY([id_rol])
REFERENCES [MIRRORING_GUYS].[Rol] ([id])
GO
ALTER TABLE [MIRRORING_GUYS].[UsuarioRol] CHECK CONSTRAINT [FK_UsuarioRol_Rol]
GO
ALTER TABLE [MIRRORING_GUYS].[UsuarioRol]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioRol_Usuario] FOREIGN KEY([id_usuario])
REFERENCES [MIRRORING_GUYS].[Usuario] ([id])
GO
ALTER TABLE [MIRRORING_GUYS].[UsuarioRol] CHECK CONSTRAINT [FK_UsuarioRol_Usuario]
GO

CREATE PROCEDURE [MIRRORING_GUYS].[Usuario_Login]
	@Username  nvarchar(50), 
    @Password nvarchar(64) 
AS
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

DECLARE @UsuarioId INT;
DECLARE @LoginFallidos INT;
DECLARE @Habilitado BIT;
DECLARE @PassBD nvarchar(64);
--Es la cantidad limite de logueos permitidos antes de inhabilitar la cuenta
DECLARE @LimiteLogueos as INT; SET @LimiteLogueos = 3 
    
	--Busco el Usuario
	SELECT @UsuarioId = Id, @Habilitado = Habilitado, @LoginFallidos = Logins_Fallidos, @PassBD = Password
    FROM MIRRORING_GUYS.Usuario
    WHERE UPPER(Username) = UPPER(@Username)

	--Verifico que exista e nombre de usuario, si no existe, lanzo excepcion
	IF @UsuarioId IS NULL
	BEGIN
		RAISERROR ('El nombre de usuario no existe. Verifique el nombre de usuario.', 16, 1)
		RETURN
	END
	ELSE
	--SI existe el usuario, realizo las demas validaciones
	BEGIN
		--si no esta habiitado, lanzo excepcion
		IF @Habilitado = 0
		BEGIN
			RAISERROR ('El usuario esta deshabilitado. Contacte al administrador.', 16, 1)
			RETURN
		END
		--si el password difiere, incremento los logins fallidos, inserto log y lanzo excepcion
		IF @PassBD <> @Password
		BEGIN
			--Incremento 1 la cantidad de logins fallidos
			SET @LoginFallidos = @LoginFallidos + 1
			DECLARE @IntentosRestantes as INT; SET @IntentosRestantes = @LimiteLogueos - @LoginFallidos

			--Actualizo la table de usuario, si los logins fallidos alcanzaron el limite, se deshabilita la cuenta
			UPDATE MIRRORING_GUYS.Usuario 
			SET Logins_Fallidos = @LoginFallidos, 
			Habilitado = CASE WHEN @LoginFallidos < @LimiteLogueos THEN 1 ELSE 0 END 
			WHERE Id = @UsuarioId

			--informo el error correspondiente
			IF @LoginFallidos < @LimiteLogueos
			BEGIN
				RAISERROR ('Ha ingresado un password incorrecto. Le quedan %d intentos.', 16, 1, @IntentosRestantes )
				RETURN
			RETURN
			END
			ELSE
			BEGIN
				RAISERROR ('Se ha inhabilitado su cuenta. Contacte al administrador.', 16, 1)
				RETURN
			END
		END

		--Si llego hasta aca, paso todas las validaciones OK
		--Borro los logins fallidos
		UPDATE MIRRORING_GUYS.Usuario SET Logins_Fallidos = 0 WHERE Id = @UsuarioId
		
		SELECT * FROM MIRRORING_GUYS.Usuario WHERE Id = @UsuarioId

	END
GO

-- INSERTS
insert into [MIRRORING_GUYS].[Usuario] ([username], [password], [logins_fallidos], [habilitado]) values
	('admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7', 0, 1)

insert into [MIRRORING_GUYS].[Usuario] ([username], [password], [logins_fallidos], [habilitado]) values
	('cobrador', 'fda9be620062a617156c1c6dbc788a6a204f85fe06e8ead0e3a43817b0e382db', 0, 1)

insert into [MIRRORING_GUYS].[Usuario] ([username], [password], [logins_fallidos], [habilitado]) values
	('superadmin', '186cf774c97b60a1c106ef718d10970a6a06e06bef89553d9ae65d938a886eae', 0, 1)

insert into [MIRRORING_GUYS].[Rol] ([nombre]) values
	('Administrador')

insert into [MIRRORING_GUYS].[Rol] ([nombre]) values
	('Cobrador')

insert into [MIRRORING_GUYS].[UsuarioRol] ([id_usuario], [id_rol]) values (
	(select id from [MIRRORING_GUYS].[Usuario] where username = 'admin'),
	(select id from [MIRRORING_GUYS].[Rol] where nombre = 'Administrador'))

insert into [MIRRORING_GUYS].[UsuarioRol] ([id_usuario], [id_rol]) values (
	(select id from [MIRRORING_GUYS].[Usuario] where username = 'cobrador'),
	(select id from [MIRRORING_GUYS].[Rol] where nombre = 'Cobrador'))

insert into [MIRRORING_GUYS].[UsuarioRol] ([id_usuario], [id_rol]) values (
	(select id from [MIRRORING_GUYS].[Usuario] where username = 'superadmin'),
	(select id from [MIRRORING_GUYS].[Rol] where nombre = 'Administrador'))

insert into [MIRRORING_GUYS].[UsuarioRol] ([id_usuario], [id_rol]) values (
	(select id from [MIRRORING_GUYS].[Usuario] where username = 'superadmin'),
	(select id from [MIRRORING_GUYS].[Rol] where nombre = 'Cobrador'))

INSERT INTO [MIRRORING_GUYS].[Funcionalidad] (nombre,formulario) VALUES ('ABM de Rol','PagoAgilFrba.AbmRol')
INSERT INTO [MIRRORING_GUYS].[Funcionalidad] (nombre,formulario) VALUES ('ABM de Cliente','PagoAgilFrba.AbmCliente')
INSERT INTO [MIRRORING_GUYS].[Funcionalidad] (nombre,formulario) VALUES ('ABM de Empresa','PagoAgilFrba.AbmEmpresa')
INSERT INTO [MIRRORING_GUYS].[Funcionalidad] (nombre,formulario) VALUES ('ABM de Factura','PagoAgilFrba.AbmFactura')
INSERT INTO [MIRRORING_GUYS].[Funcionalidad] (nombre,formulario) VALUES ('ABM de Sucursal','PagoAgilFrba.AbmSucursal')
INSERT INTO [MIRRORING_GUYS].[Funcionalidad] (nombre,formulario) VALUES ('Listado Estadistico','PagoAgilFrba.ListadoEstadistico')
INSERT INTO [MIRRORING_GUYS].[Funcionalidad] (nombre,formulario) VALUES ('Registro de Pagos','PagoAgilFrba.RegistroPago')
INSERT INTO [MIRRORING_GUYS].[Funcionalidad] (nombre,formulario) VALUES ('Rendicion','PagoAgilFrba.Rendicion')
INSERT INTO [MIRRORING_GUYS].[Funcionalidad] (nombre,formulario) VALUES ('Devolucion','PagoAgilFrba.Devolucion')

INSERT INTO [MIRRORING_GUYS].[FuncPorRol] (id_rol, id_func)
	SELECT
		(SELECT id FROM [MIRRORING_GUYS].[Rol] where nombre = 'Administrador'),
		f.id
	FROM	
		[MIRRORING_GUYS].[Funcionalidad] f

INSERT INTO [MIRRORING_GUYS].[FuncPorRol] (id_rol, id_func)
	SELECT
		(SELECT id FROM [MIRRORING_GUYS].[Rol] where nombre = 'Cobrador'),
		f.id
	FROM	
		[MIRRORING_GUYS].[Funcionalidad] f
	WHERE f.nombre IN ('ABM de Factura', 'Registro de Pagos')

CREATE TABLE MIRRORING_GUYS.Rubro (
	id						INT	IDENTITY(1,1) NOT NULL,
	rubro					NUMERIC(18,0),
	descripcion				NVARCHAR(50) NOT NULL,

	PRIMARY KEY (id)
)
GO

CREATE TABLE MIRRORING_GUYS.Empresa (
	id						INT	IDENTITY(1,1) NOT NULL,
	cuit					NVARCHAR(50) NOT NULL,
	nombre					NVARCHAR(255) NOT NULL,
	esta_activa				BIT	NOT NULL DEFAULT 1 ,
	dia_rendicion			NUMERIC(2) NOT NULL DEFAULT 1,
	id_direccion			INT NOT NULL,
	id_rubro				INT NOT NULL,

	PRIMARY KEY (id)
)
GO

CREATE TABLE MIRRORING_GUYS.Devolucion (
	id						INT	IDENTITY(1,1) NOT NULL,
	fecha					DATETIME NOT NULL,
	motivo					NVARCHAR(255) NOT NULL,
	id_factura				INT NOT NULL,
	
	PRIMARY KEY (id)
)
GO

CREATE TABLE MIRRORING_GUYS.Direccion (
	id						INT	IDENTITY(1,1) NOT NULL,
	calle   				NVARCHAR(255) NOT NULL,
	codigo_postal			NVARCHAR(255),
	
	PRIMARY KEY (id)
)
GO

CREATE TABLE MIRRORING_GUYS.Cliente (
	id						INT	IDENTITY(1,1) NOT NULL,
	dni						NUMERIC(18,0) NOT NULL,
	apellido				NVARCHAR(255) NOT NULL,
	nombre					NVARCHAR(255) NOT NULL,
	fecha_nacimiento		DATETIME NOT NULL,
	email					NVARCHAR(255) NOT NULL,
	telefono				INT,
	habilitado				BIT NOT NULL DEFAULT 1,
	id_direccion			INT NOT NULL,
	
	PRIMARY KEY (id)
)
GO

CREATE TABLE MIRRORING_GUYS.Factura (
	id						INT	IDENTITY(1,1) NOT NULL,
	nro						NUMERIC(18,0) NOT NULL,
	fecha					DATETIME NOT NULL,
	fecha_vencimiento		DATETIME NOT NULL,
	id_cliente				INT NOT NULL,
	id_empresa				INT NOT NULL,
	id_pago					INT,
	id_rendicion			INT,

	PRIMARY KEY (id)
)
GO

CREATE TABLE MIRRORING_GUYS.ItemFactura (
	id						INT	IDENTITY(1,1) NOT NULL,
	monto					NUMERIC(18,2) NOT NULL,
	cantidad				NUMERIC(18,0) NOT NULL,
	id_factura				INT NOT NULL,

	PRIMARY KEY (id)
)
GO

CREATE TABLE MIRRORING_GUYS.Sucursal (
	id						INT	IDENTITY(1,1) NOT NULL,
	nombre					NVARCHAR(50) NOT NULL,
	esta_activa				BIT	NOT NULL DEFAULT 1,
	id_direccion			INT NOT NULL,

	PRIMARY KEY (id)
)
GO

CREATE TABLE MIRRORING_GUYS.Pago (
	id						INT	IDENTITY(1,1) NOT NULL,
	nro						NUMERIC(18,0) NOT NULL,
	fecha					DATETIME NOT NULL,
	id_forma_pago			INT NOT NULL,
	id_sucursal				INT NOT NULL,
	id_cliente				INT NOT NULL,

	PRIMARY KEY (id)
)
GO

CREATE TABLE MIRRORING_GUYS.HistoricoPago (
	id						INT	IDENTITY(1,1) NOT NULL,
	id_factura				INT NOT NULL,
	id_pago					INT NOT NULL,

	PRIMARY KEY (id)
)
GO

CREATE TABLE MIRRORING_GUYS.Rendicion (
	id						INT	IDENTITY(1,1) NOT NULL,
	nro						NUMERIC(18,0) NOT NULL,
	fecha					DATETIME NOT NULL,
	porcentaje_comision		INT,

	PRIMARY KEY (id)
)
GO

CREATE TABLE MIRRORING_GUYS.FormaPago (
	id						INT	IDENTITY(1,1) NOT NULL,
	descripcion				NVARCHAR(255) NOT NULL,

	PRIMARY KEY (id)
)
GO

--ALTER TABLE [MIRRORING_GUYS].[Empresa] WITH CHECK ADD FOREIGN KEY(id_direccion) REFERENCES [MIRRORING_GUYS].[Direccion](id)
--ALTER TABLE [MIRRORING_GUYS].[Empresa] WITH CHECK ADD FOREIGN KEY(id_rubro) REFERENCES [MIRRORING_GUYS].[Rubro](id)
--ALTER TABLE [MIRRORING_GUYS].[Devolucion] WITH CHECK ADD FOREIGN KEY(id_factura) REFERENCES [MIRRORING_GUYS].[Factura](id)
--ALTER TABLE [MIRRORING_GUYS].[Direccion] WITH CHECK ADD FOREIGN KEY(id_codigo_postal) REFERENCES [MIRRORING_GUYS].[CodigoPostal](id)
--ALTER TABLE [MIRRORING_GUYS].[Cliente] WITH CHECK ADD FOREIGN KEY(id_direccion) REFERENCES [MIRRORING_GUYS].[Direccion](id)
--ALTER TABLE [MIRRORING_GUYS].[Factura] WITH CHECK ADD FOREIGN KEY(id_cliente) REFERENCES [MIRRORING_GUYS].[Cliente](id)
--ALTER TABLE [MIRRORING_GUYS].[Factura] WITH CHECK ADD FOREIGN KEY(id_empresa) REFERENCES [MIRRORING_GUYS].[Empresa](id)
--ALTER TABLE [MIRRORING_GUYS].[Factura] WITH CHECK ADD FOREIGN KEY(id_pago) REFERENCES [MIRRORING_GUYS].[Pago](id)
--ALTER TABLE [MIRRORING_GUYS].[Factura] WITH CHECK ADD FOREIGN KEY(id_rendicion) REFERENCES [MIRRORING_GUYS].[Rendicion](id)
--ALTER TABLE [MIRRORING_GUYS].[ItemFactura] WITH CHECK ADD FOREIGN KEY(id_factura) REFERENCES [MIRRORING_GUYS].[ItemFactura](id)
--ALTER TABLE [MIRRORING_GUYS].[Sucursal] WITH CHECK ADD FOREIGN KEY(id_direccion) REFERENCES [MIRRORING_GUYS].[Direccion](id)
--ALTER TABLE [MIRRORING_GUYS].[Pago] WITH CHECK ADD FOREIGN KEY(id_forma_pago) REFERENCES [MIRRORING_GUYS].[FormaPago](id)
--ALTER TABLE [MIRRORING_GUYS].[Pago] WITH CHECK ADD FOREIGN KEY(id_sucursal) REFERENCES [MIRRORING_GUYS].[Sucursal](id)
--ALTER TABLE [MIRRORING_GUYS].[Pago] WITH CHECK ADD FOREIGN KEY(id_cliente) REFERENCES [MIRRORING_GUYS].[Cliente](id)
--ALTER TABLE [MIRRORING_GUYS].[HistoricoPago] WITH CHECK ADD FOREIGN KEY(id_factura) REFERENCES [MIRRORING_GUYS].[Factura](id)
--ALTER TABLE [MIRRORING_GUYS].[HistoricoPago] WITH CHECK ADD FOREIGN KEY(id_pago) REFERENCES [MIRRORING_GUYS].[Pago](id)

INSERT INTO MIRRORING_GUYS.Rubro(descripcion)
SELECT DISTINCT Rubro_Descripcion 
FROM gd_esquema.Maestra 
WHERE Rubro_Descripcion IS NOT NULL
GO

INSERT INTO MIRRORING_GUYS.Direccion(direccion, codigo_postal)
SELECT DISTINCT Empresa_Direccion, NULL 
FROM [gd_esquema].[Maestra]
UNION
SELECT DISTINCT Cliente_Direccion, Cliente_Codigo_Postal 
FROM [gd_esquema].[Maestra]
UNION
SELECT DISTINCT Sucursal_Dirección, Sucursal_Codigo_Postal
FROM [gd_esquema].[Maestra]
WHERE Sucursal_Dirección IS NOT NULL
GO

INSERT INTO MIRRORING_GUYS.Rendicion(nro, fecha)
SELECT DISTINCT Rendicion_Nro, Rendicion_Fecha 
FROM gd_esquema.Maestra 
WHERE Rendicion_Nro IS NOT NULL
GO

INSERT INTO MIRRORING_GUYS.FormaPago(descripcion)
SELECT DISTINCT FormaPagoDescripcion 
FROM gd_esquema.Maestra 
WHERE FormaPagoDescripcion IS NOT NULL
GO

INSERT INTO MIRRORING_GUYS.Cliente(dni, nombre, apellido, email, fecha_nacimiento, id_direccion)
SELECT DISTINCT m.[Cliente-Dni], m.[Cliente-Nombre], m.[Cliente-Apellido], m.[Cliente_Mail], m.[Cliente-Fecha_Nac], d.id
FROM [gd_esquema].[Maestra] m, [MIRRORING_GUYS].[Direccion] d
WHERE m.Cliente_Codigo_Postal = d.codigo_postal AND m.Cliente_Direccion = d.direccion
GO

INSERT INTO MIRRORING_GUYS.Sucursal(nombre, id_direccion)
SELECT DISTINCT m.Sucursal_Nombre, d.id
FROM [gd_esquema].[Maestra] m, [MIRRORING_GUYS].[Direccion] d
WHERE m.Sucursal_Codigo_Postal = d.codigo_postal AND m.Sucursal_Dirección = d.direccion AND m.Sucursal_Dirección IS NOT NULL
GO

INSERT INTO MIRRORING_GUYS.Empresa(cuit, nombre, id_direccion, id_rubro)
SELECT DISTINCT m.Empresa_Cuit, m.Empresa_Nombre, d.id, r.id
FROM [gd_esquema].[Maestra] m, [MIRRORING_GUYS].[Direccion] d, [MIRRORING_GUYS].[Rubro] r
WHERE m.Empresa_Direccion = d.direccion AND m.Rubro_Descripcion = r.descripcion
GO

INSERT INTO MIRRORING_GUYS.Pago(nro, fecha, id_forma_pago, id_sucursal, id_cliente)
SELECT DISTINCT m.Pago_nro, m.Pago_Fecha, fp.id, s.id, c.id
FROM [gd_esquema].[Maestra] m, [MIRRORING_GUYS].[FormaPago] fp, [MIRRORING_GUYS].[Sucursal] s, [MIRRORING_GUYS].[Cliente] c
WHERE m.FormaPagoDescripcion = fp.descripcion AND m.Sucursal_Nombre = s.nombre AND m.[Cliente-Dni] = c.dni
ORDER BY m.Pago_nro
GO

INSERT INTO MIRRORING_GUYS.Factura(nro, fecha, fecha_vencimiento, id_cliente, id_empresa, id_pago, id_rendicion)
SELECT DISTINCT
	m.Nro_Factura, 
	m.Factura_Fecha, 
	m.Factura_Fecha_Vencimiento,
	c.id, 
	e.id,
	p.id,
	r.id
FROM [gd_esquema].[Maestra] m
LEFT JOIN [MIRRORING_GUYS].[Cliente] AS c ON m.[Cliente-Dni] = c.dni
LEFT JOIN [MIRRORING_GUYS].[Empresa] AS e ON m.Empresa_Cuit = e.cuit
RIGHT JOIN [MIRRORING_GUYS].[Pago] AS p ON m.Pago_nro = p.nro
RIGHT JOIN [MIRRORING_GUYS].[Rendicion] AS r ON m.Rendicion_Nro = r.nro
ORDER BY m.Nro_Factura
GO

INSERT INTO MIRRORING_GUYS.Factura(nro, fecha, fecha_vencimiento, id_cliente, id_empresa, id_pago)
SELECT DISTINCT
	m.Nro_Factura, 
	m.Factura_Fecha, 
	m.Factura_Fecha_Vencimiento,
	c.id, 
	e.id,
	p.id
FROM [gd_esquema].[Maestra] m
LEFT JOIN [MIRRORING_GUYS].[Cliente] AS c ON m.[Cliente-Dni] = c.dni
LEFT JOIN [MIRRORING_GUYS].[Empresa] AS e ON m.Empresa_Cuit = e.cuit
RIGHT JOIN [MIRRORING_GUYS].[Pago] AS p ON m.Pago_nro = p.nro
LEFT JOIN [MIRRORING_GUYS].[Factura] AS f ON f.nro = m.Nro_Factura
WHERE f.id IS NULL
ORDER BY m.Nro_Factura
GO

INSERT INTO MIRRORING_GUYS.Factura(nro, fecha, fecha_vencimiento, id_cliente, id_empresa)
SELECT DISTINCT
	m.Nro_Factura, 
	m.Factura_Fecha, 
	m.Factura_Fecha_Vencimiento,
	c.id, 
	e.id
FROM [gd_esquema].[Maestra] m
LEFT JOIN [MIRRORING_GUYS].[Cliente] AS c ON m.[Cliente-Dni] = c.dni
LEFT JOIN [MIRRORING_GUYS].[Empresa] AS e ON m.Empresa_Cuit = e.cuit
LEFT JOIN [MIRRORING_GUYS].[Factura] AS f ON f.nro = m.Nro_Factura
WHERE f.id IS NULL
ORDER BY m.Nro_Factura
GO

INSERT INTO MIRRORING_GUYS.ItemFactura(id_factura, cantidad, monto)
SELECT DISTINCT
	f.id,
	m.ItemFactura_Cantidad, 
	m.ItemFactura_Monto
FROM [gd_esquema].[Maestra] m, [MIRRORING_GUYS].[Factura] f 
WHERE f.nro = m.Nro_Factura
GO

INSERT INTO MIRRORING_GUYS.HistoricoPago(id_factura, id_pago)
SELECT f.id, f.id_pago
FROM [MIRRORING_GUYS].[Factura] f
WHERE f.id_pago IS NOT NULL
GO
