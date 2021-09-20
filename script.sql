--Database Creation
USE MASTER CREATE DATABASE LoanFeeControl
GO

USE LoanFeeControl

--Tables Creation
CREATE TABLE rates
(
	idRate INT IDENTITY (1, 1),
	age INT NOT NULL,
	rate decimal(10,5) NOT NULL
	CONSTRAINT pk_rate PRIMARY KEY (idRate)
)

CREATE TABLE months
(
	idMonth INT IDENTITY (1, 1),
	description varchar(100) NOT NULL,
	value INT NOT NULL
	CONSTRAINT pk_months PRIMARY KEY (idMonth)
)

--Logs creation
CREATE TABLE consult_logs
(
	idConsult INT IDENTITY (1, 1),
	date_consult date NOT NULL,
	idRate INT NOT NULL,
	amount money NOT NULL,
	idMonth INT NOT NULL,
	quota money NOT NULL,
	ip_consult varchar(25) NOT NULL
)
GO

--Initial data
INSERT INTO rates VALUES
	(18, 1.20),
	(19, 1.18),
	(20, 1.16),
	(21, 1.14),
	(22, 1.12),
	(23, 1.10),
	(24, 1.08),
	(25, 1.05);

INSERT INTO months VALUES
	('3 meses', 3),
	('6 meses', 6),
	('9 meses', 9),
	('12 meses', 12);
GO

--Stored Procedures creation
CREATE PROCEDURE sp_get_months
AS
	SELECT idMonth, description
	FROM months
GO
CREATE PROCEDURE sp_calculate_quota @age INT, @idMonth INT, @amount money, @ip varchar(25)
AS
	DECLARE @minAge AS INT;
	DECLARE @maxAge AS INT;
	DECLARE @result AS VARCHAR(200); 
	SELECT @minAge = MIN(age), @maxAge = MAX(age)
	FROM rates;

	IF (@age > @maxAge)
		BEGIN
			SET @result = 'Favor pasar por una de nuestras sucursales para evaluar su caso.';
		END
	ELSE IF (@age < @minAge)
		BEGIN
			SET @result = 'Lo Sentimos aun no cuenta con la edad para solicitar este producto.';
		END
	ELSE
		BEGIN
			DECLARE @rate AS DECIMAL(10,5);
			DECLARE @idRate AS INT;
			DECLARE @month AS INT;
			DECLARE @quota AS money;
			SELECT @idRate = idRate, @rate = rate
			FROM rates
			WHERE age = @age;
			SELECT @month = value
			FROM months
			WHERE idMonth = @idMonth;
			SET @quota = (@amount * @rate) / @month;
			INSERT INTO consult_logs VALUES
				(GETDATE(), @idRate, @amount, @idMonth, @quota, @ip);
			SET @result = CONVERT(VARCHAR, @quota);
		END
	SELECT @result;
GO
CREATE PROCEDURE sp_get_log
AS
	SELECT 
		CL.idConsult [ID de consulta],
		CL.date_consult [Fecha de consulta],
		R.age [Edad],
		CL.amount [Monto],
		M.description [Meses],
		CL.quota [Valor Cuota],
		CL.ip_consult [IP_de_Consulta]
	FROM consult_logs CL
	INNER JOIN months M ON M.idMonth = CL.idMonth
	INNER JOIN rates R ON R.idRate = CL.idRate
GO