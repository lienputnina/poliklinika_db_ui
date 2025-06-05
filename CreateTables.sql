USE Poliklinika;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Pacienti' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
   CREATE TABLE dbo.Pacienti 
           (PacientaKartinasNumurs varchar(15) NOT NULL, Uzvards nvarchar(30), Vards nvarchar(20), Iela nvarchar (50), Maja int, Dzivoklis int, Pilseta nvarchar (20), Rajons nvarchar (20), PastaIndekss nvarchar (10), TelefonaNumurs nvarchar (20), PRIMARY KEY (PacientaKartinasNumurs)); 
 END

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Konsultacijas' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
   CREATE TABLE dbo.Konsultacijas (KonsultacijasNumurs nvarchar(15) NOT NULL, Nosaukums nvarchar (100), Cena float, PRIMARY KEY (KonsultacijasNumurs)); 
END

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Arsti' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
  CREATE TABLE dbo.Arsti (ArstaPersonasKods nvarchar(15) NOT NULL, Uzvards nvarchar (30), Vards nvarchar (20), TelefonaNumurs nvarchar (20), Epasts nvarchar (50), PRIMARY KEY (ArstaPersonasKods)); 
END

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Kabineti' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
  CREATE TABLE dbo.Kabineti (KabinetaNumurs int NOT NULL, Nosaukums nvarchar (100), TelefonaNumurs nvarchar (20), PRIMARY KEY (KabinetaNumurs));
END

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Registrs' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
  CREATE TABLE dbo.Registrs (Datums date, KonsultacijasSakums time, KonsultacijasBeigas time, KabinetaNumurs int, KonsultacijasNumurs nvarchar(15), ArstaPersonasKods nvarchar (15), PacientaKartinasNumurs varchar(15) NOT NULL, PRIMARY KEY (Datums, KonsultacijasSakums, KabinetaNumurs, KonsultacijasNumurs, ArstaPersonasKods, PacientaKartinasNumurs), CONSTRAINT FK_KabinetaNumurs FOREIGN KEY (KabinetaNumurs) REFERENCES Kabineti (KabinetaNumurs), CONSTRAINT FK_KonsultacijasNumurs FOREIGN KEY (KonsultacijasNumurs) REFERENCES Konsultacijas (KonsultacijasNumurs), CONSTRAINT FK_ArstaPersonasKods FOREIGN KEY (ArstaPersonasKods) REFERENCES Arsti (ArstaPersonasKods), CONSTRAINT FK_PacientaKartinasNumurs FOREIGN KEY (PacientaKartinasNumurs) REFERENCES Pacienti (PacientaKartinasNumurs));
END