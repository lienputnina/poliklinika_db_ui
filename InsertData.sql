
IF NOT EXISTS (
  SELECT 1 FROM Pacienti WHERE PacientaKartinasNumurs = '2025-0001'
)
INSERT INTO Pacienti VALUES ('2025-0001', 'Ozola', 'Madara', 'Rīgas', '32', '5', 'Liepāja', 'Liepājas', 'LV – 3401', '+37126612345');

IF NOT EXISTS (
  SELECT 1 FROM Pacienti WHERE PacientaKartinasNumurs = '2025-0002'
)
INSERT INTO Pacienti VALUES ('2025-0002', 'Bērziņš', 'Linards', 'Kokles', '15', '65', 'Rīga', 'Rīgas', 'LV – 1029', '+37124494859');

IF NOT EXISTS (
  SELECT 1 FROM Pacienti WHERE PacientaKartinasNumurs = '2025-0003'
)
INSERT INTO Pacienti VALUES ('2025-0003', 'Kļaviņa', 'Lauma', 'Tērbatas', '14', '10', 'Valmiera', 'Valmieras', 'LV – 4201', '+37125516868');

IF NOT EXISTS (
  SELECT 1 FROM Pacienti WHERE PacientaKartinasNumurs = '2025-0004'
)
INSERT INTO Pacienti VALUES ('2025-0004', 'Kārkliņš', 'Elvijs', 'Ainavu', '4', '2', 'Sigulda', 'Siguldas', 'LV – 2150', '+37129912323');

IF NOT EXISTS (
  SELECT 1 FROM Pacienti WHERE PacientaKartinasNumurs = '2025-0005'
 )
INSERT INTO Pacienti VALUES ('2025-0005', 'Liepa', 'Ilga', 'Ābeļu', '5', '1', 'Jelgava', 'Jelgavas', 'LV-3008', '+37129912366');


IF NOT EXISTS (
  SELECT 1 FROM Konsultacijas WHERE KonsultacijasNumurs = '2025-0001-01'
 )
INSERT INTO Konsultacijas VALUES ('2025-0001-01', 'Ginekologa konsultācija', '80');

IF NOT EXISTS (
  SELECT 1 FROM Konsultacijas WHERE KonsultacijasNumurs = '2025-0002-02'
)
INSERT INTO Konsultacijas VALUES ('2025-0002-02', 'Urologa konsultācija', '50');

IF NOT EXISTS (
  SELECT 1 FROM Konsultacijas WHERE KonsultacijasNumurs = '2025-0003-03'
)
INSERT INTO Konsultacijas VALUES ('2025-0003-03', 'Operējoša Otolaringologa (LOR) konsultācija', '65');

IF NOT EXISTS (
  SELECT 1 FROM Konsultacijas WHERE KonsultacijasNumurs = '2025-0004-04'
)
INSERT INTO Konsultacijas VALUES ('2025-0004-04', 'Neiroķirurga konsultācija bērnam', '4.72');

IF NOT EXISTS (
  SELECT 1 FROM Konsultacijas WHERE KonsultacijasNumurs = '2025-0005-05'
)
INSERT INTO Konsultacijas VALUES ('2025-0005-05', 'Rentgens (RTG, radioloģisks izmeklējums, nosūtījums obligāts)', '50');

IF NOT EXISTS (
  SELECT 1 FROM Arsti WHERE ArstaPersonasKods = '120286-12233'
 )
INSERT INTO Arsti VALUES ('120286-12233', 'Žagata', 'Līga', '+3713344755', 'liga.zagata@poliklinika.lv');

IF NOT EXISTS (
  SELECT 1 FROM Arsti WHERE ArstaPersonasKods = '151168-41166'
)
INSERT INTO Arsti VALUES ('151168-41166', 'Krauklis', 'Kristaps', '+3715566991', 'kristaps.krauklis@poliklinika.lv');

IF NOT EXISTS (
  SELECT 1 FROM Arsti WHERE ArstaPersonasKods = '180593-26655'
)
INSERT INTO Arsti VALUES ('180593-26655', 'Dzērve', 'Jānis', '+3712211668', 'janis.dzerve@poliklinika.lv');

IF NOT EXISTS (
  SELECT 1 FROM Arsti WHERE ArstaPersonasKods = '200675-36600'
)
INSERT INTO Arsti VALUES ('200675-36600', 'Lakstīgala', 'Daina', '+3714455883', 'daina.lakstigala@poliklinika.lv');

IF NOT EXISTS (
  SELECT 1 FROM Arsti WHERE ArstaPersonasKods = '261066-53311'
)
INSERT INTO Arsti VALUES ('261066-53311', 'Dzenis', 'Mārtiņš', '+3716677123', 'martins.dzenis@poliklinika.lv');


IF NOT EXISTS (
  SELECT 1 FROM Kabineti WHERE KabinetaNumurs = '105'
 )
INSERT INTO Kabineti VALUES ('105', 'Ginekologs', '+3716755123');

IF NOT EXISTS (
  SELECT 1 FROM Kabineti WHERE KabinetaNumurs = '202'
)
INSERT INTO Kabineti VALUES ('202', 'Urologs', '+3716731122');

IF NOT EXISTS (
  SELECT 1 FROM Kabineti WHERE KabinetaNumurs = '304'
 )
INSERT INTO Kabineti VALUES ('304', 'Otolaringologs', '+3716753005');

IF NOT EXISTS (
  SELECT 1 FROM Kabineti WHERE KabinetaNumurs = '403'
 )
INSERT INTO Kabineti VALUES ('403', 'Neiroķirurgs', '+3716741978');

IF NOT EXISTS (
  SELECT 1 FROM Kabineti WHERE KabinetaNumurs = '501'
)
INSERT INTO Kabineti VALUES ('501', 'Radiologs', '+3716791357');


IF NOT EXISTS (
  SELECT 1 FROM Registrs WHERE KonsultacijasNumurs = '2025-0001-01'
)
INSERT INTO Registrs  VALUES ('2025-0001-01', '2025.03.21', '09:30:00', '09:45:00', '105', '180593-26655', '2025-0001');

IF NOT EXISTS (
  SELECT 1 FROM Registrs WHERE KonsultacijasNumurs = '2025-0002-02'
)
INSERT INTO Registrs  VALUES 
('2025-0002-02', '2025.03.30', '11:45:00', '12:00:00', '202', '120286-12233', '2025-0002');

IF NOT EXISTS (
  SELECT 1 FROM Registrs WHERE KonsultacijasNumurs = '2025-0003-03'
)
INSERT INTO Registrs  VALUES ('2025.04.14', '12:00:00', '12:15:00', '304', '2025-0002-03', '120286-12233', '2025-0002');

IF NOT EXISTS (
  SELECT 1 FROM Registrs WHERE KonsultacijasNumurs = '2025-0004-04'
 )
INSERT INTO Registrs  VALUES ('2025-0003-03', '2025.04.14', '12:00:00', '12:15:00', '304', '200675-36600', '2025-0003');


IF NOT EXISTS (
  SELECT 1 FROM Registrs WHERE KonsultacijasNumurs = '2025-0005-04')
INSERT INTO Registrs  VALUES ('2025-0004-04', '2025.04.21', '08:20:00', '08:40:00', '403', '151168-41166', '2025-0004');


IF NOT EXISTS (
  SELECT 1 FROM Registrs WHERE KonsultacijasNumurs = '2025-0005-05'
)
INSERT INTO Registrs  VALUES ('2025-0005-05', '2025.06.06', '17:10:00', '17:20:00', '501', '261066-53311', '2025-0005');
