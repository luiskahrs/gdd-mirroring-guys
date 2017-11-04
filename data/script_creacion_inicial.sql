USE [GD2C2017]
GO
/****** Object:  User [gd]    Script Date: 04/11/2017 18:35:51 ******/
CREATE USER [gd] FOR LOGIN [gd] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Schema [MIRRORING_GUYS]    Script Date: 04/11/2017 18:35:52 ******/
CREATE SCHEMA [MIRRORING_GUYS]
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
	[nombre] [varchar](20) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
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
	[descripcion] [varchar](50) NOT NULL,
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
	[username] [varchar](20) NOT NULL,
	[password] [char](64) NOT NULL,
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