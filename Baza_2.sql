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
kategorija_ime nvarchar(100)
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

ALTER table Artikal
add constraint FK_slika_id
FOREIGN KEY (ime)
REFERENCES Slika(slika_id);

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
@korisnik_id int,
@ime_korisnik nvarchar(100),
@prezime_korisnik nvarchar(100),
@lozinka_hash nvarchar(255),
@email nvarchar(255),
@drzava nvarchar(100),
@grad nvarchar(100),
@opstina nvarchar(100),
@postanski_br int,
@adresa nvarchar(255),
@is_administrator BIT,
@pol nvarchar(10)
AS
SET LOCK_TIMEOUT 3000;
BEGIN TRY
	IF EXISTS (SELECT TOP 1 ime_korisnik FROM Korisnik
	WHERE korisnik_id = @korisnik_id)

	BEGIN
	DECLARE @tip_korisnik_id INT
	select @tip_korisnik_id = tip_korisnik_id from Korisnik where korisnik_id = @korisnik_id
	Update Korisnik Set ime_korisnik=@ime_korisnik, prezime_korisnik=@prezime_korisnik, lozinka_hash=@lozinka_hash, email=@email, @drzava=@drzava, grad=@grad, opstina=@opstina, postanski_br=@postanski_br, adresa=@adresa, pol=@pol where korisnik_id = @korisnik_id
	Update TipKorisnik Set is_administrator=@is_administrator where tip_korisnik_id = @tip_korisnik_id
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
@korisnik_id int
as
Begin TRY
DECLARE @tip_korisnik_id INT
select @tip_korisnik_id = tip_korisnik_id from Korisnik where korisnik_id = @korisnik_id
Delete from Korisnik where korisnik_id = @korisnik_id
Delete from TipKorisnik where tip_korisnik_id = @tip_korisnik_id
END TRY
BEGIN CATCH
	RETURN @@ERROR;
END CATCH
GO
