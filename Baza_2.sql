create database webshop2
use webshop2

Create table Artikal(
artikal_id INT Primary Key identity(1,1),
ime nvarchar(255) not null,
cena int not null,
statusArtikla_id int,
kategorija_id int,
opis nvarchar(250),
magacin int
)

Create table Kategorija (
kategorija_id int Primary Key identity(1,1),
kategorija_ime nvarchar(100) unique
)

Create table StatusArtikla (
statusArtikla_id int Primary Key identity(1,1),
is_vidljivo BIT default(0)
)

Create table Slika (
slika_id nvarchar(255) Primary Key not null,
slika_ref nvarchar(150) not null unique
)

Create table Porudzbina (
porudzbina_id INT PRIMARY KEY identity(1,1),
korisnik_id INT not null,
artikal_id INT not null,
is_zavrseno BIT DEFAULT (0),
vreme_porudzbina DATETIME NOT NULL,
kolicina_kupovine INT NOT NULL
)

Create table Korisnik (
korisnik_id int Primary Key identity(1,1),
ime_korisnik nvarchar(100) not null,
prezime_korisnik nvarchar(100) not null,
lozinka_hash nvarchar(255) not null,
email nvarchar(255) not null unique,
drzava nvarchar(100) not null,
grad nvarchar(100) not null,
opstina nvarchar(100) not null,
postanski_br int not null,
adresa nvarchar(255) not null,
tip_korisnik_id int,
pol nvarchar(10) not null check (pol in('Musko', 'Zensko'))
)

Create table TipKorisnik (
tip_korisnik_id int Primary Key identity(1,1),
is_administrator BIT DEFAULT (0)
)


/*-------------------------------------------------*/


ALTER table Artikal
add constraint FK_statusArtikla_id
FOREIGN KEY (statusArtikla_id)
REFERENCES StatusArtikla(statusArtikla_id);

ALTER table Artikal
add constraint FK_kategorija_id
FOREIGN KEY (kategorija_id)
REFERENCES Kategorija(kategorija_id);
/*
ALTER table Artikal
add constraint FK_slika_id
FOREIGN KEY (ime)
REFERENCES Slika(slika_id);
*/
ALTER table Porudzbina
add constraint FK_korisnik_id
FOREIGN KEY (korisnik_id)
REFERENCES Korisnik(korisnik_id);

ALTER table Porudzbina
add constraint FK_artikal_id
FOREIGN KEY (artikal_id)
REFERENCES Artikal(artikal_id);

ALTER table Korisnik
add constraint FK_tip_korisnik_id
FOREIGN KEY (tip_korisnik_id)
REFERENCES TipKorisnik(tip_korisnik_id);


/*-------------------------------------------------*/


/*----------TipKorisnik----------*/

GO
CREATE PROC TipKorisnik_Insert
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	Insert Into TipKorisnik(is_administrator)
	Values(0)
		RETURN SCOPE_IDENTITY()
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO

GO
Create PROC TipKorisnik_Update
@email nvarchar(255),
@is_administrator BIT 
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	IF EXISTS (SELECT TOP 1 email FROM Korisnik
	WHERE email = @email )
	BEGIN
	DECLARE @tip_korisnik_id INT
	select @tip_korisnik_id = tip_korisnik_id from Korisnik where email = @email
	Update TipKorisnik Set is_administrator = @is_administrator where tip_korisnik_id = @tip_korisnik_id
		RETURN 0;
	END
	RETURN 1;
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO

/*----------Korisnik----------*/

GO
Create PROC Korisnik_Insert
@ime_korisnik nvarchar(100),
@prezime_korisnik nvarchar(100),
@lozinka_hash nvarchar(255),
@email nvarchar(255),
@drzava nvarchar(100),
@grad nvarchar(100),
@opstina nvarchar(100),
@postanski_br int,
@adresa nvarchar(255), 
@pol nvarchar(10)
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	IF EXISTS(SELECT TOP 1 email FROM Korisnik
	WHERE email = @email)
	Return 1
	else
	DECLARE @tip_korisnik_id INT
	EXEC @tip_korisnik_id = TipKorisnik_Insert
	Insert Into Korisnik(ime_korisnik,prezime_korisnik,lozinka_hash,email,drzava,grad,opstina,postanski_br,adresa,tip_korisnik_id,pol)
	Values(@ime_korisnik,@prezime_korisnik,@lozinka_hash,@email,@drzava,@grad,@opstina,@postanski_br,@adresa,@tip_korisnik_id,@pol)
		RETURN 0;
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO

GO
Create PROC Korisnik_Update
@ime_korisnik nvarchar(100),
@prezime_korisnik nvarchar(100),
@lozinka_hash nvarchar(255),
@email nvarchar(255),
@drzava nvarchar(100),
@grad nvarchar(100),
@opstina nvarchar(100),
@postanski_br int,
@adresa nvarchar(255),
@pol nvarchar(10)
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	IF EXISTS (SELECT TOP 1 ime_korisnik FROM Korisnik
	WHERE email = @email)
	BEGIN
	Update Korisnik Set ime_korisnik=@ime_korisnik, prezime_korisnik=@prezime_korisnik, lozinka_hash=@lozinka_hash, email=@email, drzava=@drzava, grad=@grad, opstina=@opstina, postanski_br=@postanski_br, adresa=@adresa, pol=@pol where email = @email
		RETURN 0;
	END
	RETURN 1;
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO

Go
Create Proc Korisnik_Delete
@email nvarchar(255)
as
Begin TRY
DECLARE @tip_korisnik_id INT
select @tip_korisnik_id = tip_korisnik_id from Korisnik where email = @email
Delete from Korisnik where email = @email
Delete from TipKorisnik where tip_korisnik_id = @tip_korisnik_id
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
Go

/*----------StatusArtikla----------*/

GO
CREATE PROC StatusArtikla_Insert
@is_vidljivo BIT
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	Insert Into StatusArtikla(is_vidljivo)
	Values(@is_vidljivo)
		RETURN SCOPE_IDENTITY();
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO

GO
Create PROC StatusArtikla_Update
@artikal_id int,
@is_vidljivo BIT
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	IF EXISTS (SELECT TOP 1 artikal_id FROM Artikal
	WHERE artikal_id = @artikal_id)
	BEGIN
	DECLARE @statusArtikla_id INT
	SELECT @statusArtikla_id = statusArtikla_id FROM Artikal WHERE artikal_id = @artikal_id
	Update StatusArtikla Set is_vidljivo = @is_vidljivo where statusArtikla_id = @statusArtikla_id
		RETURN 0;
	END
	RETURN 1;
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO

/*----------Kategorija----------*/

GO
CREATE PROC Kategorija_Insert
@kategorija_ime nvarchar(100)
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	IF EXISTS(SELECT TOP 1 kategorija_ime FROM Kategorija
	WHERE kategorija_ime = @kategorija_ime)
	Return 1
	else
	Insert Into Kategorija(kategorija_ime)
	Values(@kategorija_ime)
		RETURN 0;
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO

GO
Create PROC Kategorija_Update
@kategorija_id int,
@kategorija_ime nvarchar(100)
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	IF EXISTS (SELECT TOP 1 kategorija_ime FROM Kategorija
	WHERE kategorija_id = @kategorija_id)
	BEGIN
	Update Kategorija Set kategorija_ime = @kategorija_ime where kategorija_id = @kategorija_id
		RETURN 0;
	END
	RETURN 1;
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO

Go
Create Proc Kategorija_Delete
@kategorija_id int,
@kategorija_ime nvarchar(100)
AS
Begin TRY
DELETE FROM Kategorija WHERE kategorija_ime = @kategorija_ime AND kategorija_id = @kategorija_id
RETURN 0
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO

/*----------Slika----------*/

/*
GO
CREATE PROC Slika_Insert
@slika_ref NVARCHAR(150)
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	IF EXISTS(SELECT TOP 1 slika_ref FROM Slika
	WHERE slika_ref = @slika_ref)
	RETURN 1
	ELSE
	INSERT INTO Slika(slika_ref)
	VALUES(@slika_ref)
		RETURN SCOPE_IDENTITY();
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO
*/

/*----------Artikal----------*/

GO
Create PROC Artikal_Insert
@ime nvarchar(255),
@cena int,
@is_vidljivo int,
@kategorija_ime nvarchar(100),
@opis nvarchar(250),
@magacin int
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	IF EXISTS(SELECT TOP 1 ime FROM Artikal
	WHERE ime = @ime and magacin = @magacin)
	Return 1
	else
	DECLARE @kategorija_id INT
	SELECT @kategorija_id = kategorija_id FROM Kategorija WHERE kategorija_ime = @kategorija_ime
	DECLARE @statusArtikla_id INT
	EXEC @statusArtikla_id = StatusArtikla_Insert @is_vidljivo
	Insert Into Artikal(ime, cena, statusArtikla_id, kategorija_id, opis, magacin)
	Values(@ime, @cena, @statusArtikla_id, @kategorija_id, @opis, @magacin)
		RETURN 0;
END TRY
	
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO
