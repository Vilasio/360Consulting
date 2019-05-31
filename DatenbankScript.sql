CREATE SCHEMA Parkgarage;

CREATE EXTENSION pgcrypto;

--*************************************************
-- alle drop statements
--*************************************************
ALTER TABLE Parkgarage.spot DROP CONSTRAINT spot_vehicle_fk;


DROP SEQUENCE Parkagarage.garage_seq;
DROP SEQUENCE Parkagarage.spot_seq;
DROP SEQUENCE Parkagarage.vehicle_seq;


DROP TABLE Parkgarage.garage;
DROP TABLE Parkgarage.spot;
DROP TABLE Parkgarage.vehicle;

--*************************************************
-- Garage
--*************************************************
CREATE TABLE Parkgarage.garage
(
	garage_id			NUMERIC(10) not null,
	floors			    NUMERIC(10),	
	spots			  	NUMERIC(10),


	CONSTRAINT garage_pk PRIMARY KEY (garage_id)
	

);

CREATE SEQUENCE Parkgarage.garage_seq START WITH 1 INCREMENT bY 1;

--*************************************************
-- Vehicle
--*************************************************
CREATE TABLE Parkgarage.spot
(
	spot_id				NUMERIC(10) not null,
	vehicle_id			NUMERIC(10),
	floors				NUMERIC(5),
	spot				NUMERIC(5),
	
	

	CONSTRAINT spot_pk PRIMARY KEY (spot_id)
	

);

CREATE SEQUENCE Parkgarage.spot_seq START WITH 1 INCREMENT bY 1;

--*************************************************
-- Vehicle
--*************************************************
CREATE TABLE Parkgarage.vehicle
(
	vehicle_id			NUMERIC(10) not null,
	numberplate			VARCHAR(250) not null,
	position_floor		NUMERIC(5),
	position_spot		NUMERIC(5),
	kind				VARCHAR(50),
	
	
	CONSTRAINT numberplate_uk UNIQUE (numberplate),
	CONSTRAINT vehicle_pk PRIMARY KEY (vehicle_id)
	

);

CREATE SEQUENCE Parkgarage.vehicle_seq START WITH 1 INCREMENT bY 1;

--*************************************************
-- Views
--*************************************************



--*************************************************
-- constraints
--*************************************************

alter table Parkgarage.spot add constraint	  spot_vehicle_fk      foreign key (vehicle_id) references Parkgarage.vehicle (vehicle_id);

--*************************************************
-- Grants
--*************************************************
GRANT USAGE ON SCHEMA Parkgarage TO clerk;
grant select, insert, update, delete on Parkgarage.garage to clerk;
grant select, insert, update, delete on Parkgarage.spot to clerk;
grant select, insert, update, delete on Parkgarage.vehicle to clerk;



GRANT SELECT, USAGE ON SEQUENCE Parkgarage.garage_seq to clerk;
GRANT SELECT, USAGE ON SEQUENCE Parkgarage.spot_seq to clerk;
GRANT SELECT, USAGE ON SEQUENCE Parkgarage.vehicle_seq to clerk;



--*************************************************
-- otherstuff
--*************************************************
CREATE USER clerk WITH
	LOGIN
	NOSUPERUSER
	NOCREATEDB
	NOCREATEROLE
	INHERIT
	NOREPLICATION
	CONNECTION LIMIT -1;