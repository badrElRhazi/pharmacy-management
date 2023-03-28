create database Pharmacie
use Pharmacie
create table Medicament( 
	NumMedicament int primary key,
	designation varchar(30),
	forme varchar(30),
	datePeremption date,
	StockActuel int
	)
create table Medecin( 
	NumMedecin int primary key,
	NomMd varchar(30),
	prenomMD varchar(30),
	specialité varchar(30),
	loginMD varchar(30) unique,
	passMd varchar(30)
	)
create table Pharmacien( 
	NumPh int primary key,
	NomPh varchar(30),
	prenomPh varchar(30),
	loginPh varchar(30) unique,
	passPh varchar(30)
	)
create table Patient( 
	NumPatient int primary key,
	NomP varchar(30),
	prenomP varchar(30),
	DateNaissance date,
	)
create table Ordonnance( 
	NumOrdonnance int primary key identity,
	NumPatient int foreign key references Patient(NumPatient),
	NumMedecin int foreign key references Medecin(NumMedecin),
	DateOrdonnance date,
	)
create table DetailOrdonnance( 
	NumOrdonnance int foreign key references Ordonnance(NumOrdonnance) ,
	NumMedicament int foreign key references Medicament(NumMedicament),
	QttePrescrite int,
	primary key(NumOrdonnance,NumMedicament)
	)
	
select do.NumOrdonnance, do.NumMedicament, orr.DateOrdonnance from DetailOrdonnance do  
                inner join Ordonnance orr on orr.NumOrdonnance=do.NumOrdonnance inner join Medecin m on m.NumMedecin=orr.NumMedecin


"select do.NumOrdonnance, do.NumMedicament,ord.DateOrdonnance from DetailOrdonnance do " +
                "inner join Ordonnance ord on ord.NumOrdonnance=do.NumOrdonnance" +
                "inner join Medecin m on m.NumMedecin=ord.NumMedecin where (ord.NumPatient=@a) and( m.loginMD=@b)";