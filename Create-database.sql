CREATE DATABASE IF NOT EXISTS windows_form_connect
    DEFAULT CHARACTER SET = utf8
    DEFAULT COLLATE = utf8_unicode_ci;
USE windows_form_connect;

CREATE TABLE users (
  id	BIGINT(20) PRIMARY KEY AUTO_INCREMENT,
  name	VARCHAR(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO users (`name`) VALUES ("Eldar"), ("Micle"), ("John");

-- SHOW DATABASES;
