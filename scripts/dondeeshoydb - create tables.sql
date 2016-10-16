
CREATE TABLE establishments_type (
     id MEDIUMINT NOT NULL AUTO_INCREMENT,
     name CHAR(45) NOT NULL,
     PRIMARY KEY (id)
);


CREATE TABLE establishments (
     id MEDIUMINT NOT NULL AUTO_INCREMENT,
     name CHAR(45) NOT NULL,
     establishment_type MEDIUMINT,
	 imagebase64 text,
	 telefono CHAR(20),
     FOREIGN KEY (establishment_type) references establishments_type(id),
     PRIMARY KEY (id)
);



CREATE TABLE establishments_accounts (
     id MEDIUMINT NOT NULL AUTO_INCREMENT,
	 establishment MEDIUMINT NOT NULL,
     name CHAR(45) NOT NULL,
     password CHAR(45) NOT NULL,
     email CHAR(50) UNIQUE NOT NULL,
	 imagebase64 text,
	 FOREIGN KEY (establishment) references establishments(id),
     PRIMARY KEY (id)
);

CREATE TABLE establishments_accounts_logs (
	 id MEDIUMINT NOT NULL AUTO_INCREMENT,
     date datetime NOT NULL,
     description text NOT NULL,
     establishments_accounts MEDIUMINT,
     FOREIGN KEY (establishments_accounts) references establishments_accounts(id),
	 PRIMARY KEY (id)
);


CREATE TABLE locals (
     id MEDIUMINT NOT NULL AUTO_INCREMENT,
     establishment MEDIUMINT NOT NULL,
     google_key CHAR(200),
     zone  CHAR(200),
	 telefono CHAR(20),
     FOREIGN KEY (establishment) references establishments(id),
     PRIMARY KEY (id)
);


CREATE TABLE promos_events (
     id MEDIUMINT NOT NULL AUTO_INCREMENT,
     name CHAR(45),
     start_date datetime NOT NULL,
     due_date datetime NOT NULL,
     description TEXT NOT NULL,
     local MEDIUMINT NOT NULL,
     imagebase64 text ,
	 is_general bit,
     FOREIGN KEY (local) references locals(id),
     PRIMARY KEY (id)
);



CREATE TABLE users (
     id MEDIUMINT NOT NULL AUTO_INCREMENT,
     name CHAR(45) NOT NULL,
     password CHAR(45) NOT NULL,
     email CHAR(45) UNIQUE NOT NULL,
	 lastName CHAR(45) NOT NULL,
	 imagebase64 text ,
     PRIMARY KEY (id)
);


CREATE TABLE users_favorites_establishments (
	id MEDIUMINT NOT NULL AUTO_INCREMENT,
     user MEDIUMINT NOT NULL,
     establishment MEDIUMINT NOT NULL,
     FOREIGN KEY (establishment) references establishments(id),
     FOREIGN KEY (user) references users(id),
	 PRIMARY KEY (id)
);



