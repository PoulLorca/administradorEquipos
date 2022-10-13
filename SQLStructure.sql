CREATE DATABASE PCE
GO

USE PCE
GO

CREATE TABLE Equipo(
	EquipoId INT IDENTITY(1,1) NOT NULL,
	NombreEquipo VARCHAR(255) UNIQUE NOT NULL,
	CantidadJugadores INT NOT NULL,
	NombreDT VARCHAR(255) NOT NULL,
	TipoEquipo VARCHAR(255) NOT NULL,
	CapitanEquipo VARCHAR(255) NOT NULL,
	TieneSub21 BIT NOT NULL,
	CONSTRAINT Pk_Equipo_EquipoId PRIMARY KEY (EquipoId)
)
GO

SELECT * FROM Equipo
GO

--View--
CREATE VIEW vwEquipo
AS
	SELECT EquipoId, NombreEquipo, CantidadJugadores, NombreDT, TipoEquipo, CapitanEquipo, TieneSub21 FROM PCE.dbo.Equipo
GO

SELECT * FROM vwEquipo
GO

--Functions--
CREATE FUNCTION fxObtenerCantidadEquiposFemeninos()
RETURNS INT AS
	BEGIN
		RETURN (SELECT COUNT(EquipoId) FROM vwEquipo WHERE TipoEquipo = 'femenino')
	END
GO

SELECT PCE.dbo.fxObtenerCantidadEquiposFemeninos() AS 'Equipos Femeninos'
GO

CREATE FUNCTION fxObtenerCantidadEquiposMasculinos()
RETURNS INT AS
	BEGIN
		RETURN (SELECT COUNT(EquipoId) FROM vwEquipo WHERE TipoEquipo = 'masculino')
	END
GO

SELECT PCE.dbo.fxObtenerCantidadEquiposMasculinos() AS 'Equipos Masculinos'
GO

--Procedures--
CREATE PROCEDURE spEquipoSave
	@NombreEquipo VARCHAR(255),
	@CantidadJugadores INT,
	@NombreDT VARCHAR(255),
	@TipoEquipo VARCHAR(255),
	@CapitanEquipo VARCHAR(255),
	@TieneSub21 BIT
AS
	INSERT INTO PCE.dbo.Equipo(NombreEquipo, CantidadJugadores, NombreDT, TipoEquipo, CapitanEquipo, TieneSub21) VALUES (@NombreEquipo,@CantidadJugadores,@NombreDT,@TipoEquipo,@CapitanEquipo,@TieneSub21)
GO

EXEC PCE.dbo.spEquipoSave
	@NombreEquipo = 'COLO-COLO',
	@CantidadJugadores =  12,
	@NombreDT = 'Marcelo Bielsa',
	@TipoEquipo = 'masculino',
	@CapitanEquipo = 'Peluca Perez',
	@TieneSub21 = 0 
GO

CREATE PROCEDURE spEquipoUpdateById
	@EquipoId INT,
	@NombreEquipo VARCHAR(255),
	@CantidadJugadores INT,
	@NombreDT VARCHAR(255),
	@TipoEquipo VARCHAR(255),
	@CapitanEquipo VARCHAR(255),
	@TieneSub21 BIT
AS
	UPDATE PCE.dbo.Equipo SET NombreEquipo = @NombreEquipo, CantidadJugadores = @CantidadJugadores, NombreDT =  @NombreDT, TipoEquipo = @TipoEquipo, CapitanEquipo = @CapitanEquipo, TieneSub21 = @TieneSub21  WHERE EquipoId = @EquipoId
GO

EXEC PCE.dbo.spEquipoUpdateById
	@EquipoId = 1,
	@NombreEquipo = 'COLO-COLO',
	@CantidadJugadores =  12,
	@NombreDT = 'Marcelo Bielsa',
	@TipoEquipo = 'femenino',
	@CapitanEquipo = 'Peluca Perez',
	@TieneSub21 = 0 
GO

CREATE PROCEDURE spEquipoDeleteById
	@EquipoId INT
AS
	DELETE FROM PCE.dbo.Equipo WHERE EquipoId = @EquipoId
GO

EXEC PCE.dbo.spEquipoDeleteById @EquipoId = 1
GO

--Special Procedures--
CREATE PROCEDURE spObtenerCantidadEquiposFemeninos
AS
	SELECT PCE.dbo.fxObtenerCantidadEquiposFemeninos() AS 'Equipos Femeninos'
GO

EXEC PCE.dbo.spObtenerCantidadEquiposFemeninos
GO

CREATE PROCEDURE spObtenerCantidadEquiposMasculinos
AS
	SELECT PCE.dbo.fxObtenerCantidadEquiposMasculinos() AS 'Equipos Masculinos'
GO

EXEC PCE.dbo.spObtenerCantidadEquiposMasculinos
GO