-- Tables
CREATE TABLE user (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    username VARCHAR(255) UNIQUE NOT NULL,
    email VARCHAR(255) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    password_salt VARCHAR(255) NOT NULL
);

CREATE TABLE system_parameter (
    id INT AUTO_INCREMENT PRIMARY KEY,
    code INT UNIQUE NOT NULL,
    name VARCHAR(255) NOT NULL,
    description TEXT NOT NULL,
    type VARCHAR(1) NOT NULL,
    value TEXT NOT NULL,
    is_editable BOOL NOT NULL
);

CREATE TABLE system_message (
    id INT AUTO_INCREMENT PRIMARY KEY,
    code INT UNIQUE NOT NULL,
    name VARCHAR(255) NOT NULL,
    description TEXT NOT NULL,
    value TEXT NOT NULL,
    is_editable BOOL NOT NULL
);

CREATE TABLE system_log (
    id INT AUTO_INCREMENT PRIMARY KEY,
    message TEXT NOT NULL,
    stack_trace TEXT NULL,
    type VARCHAR(255) NOT NULL,
    user_id INT NULL,
    date DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE product (
    id INT AUTO_INCREMENT PRIMARY KEY,
    price DECIMAL(10, 2) NOT NULL,
    name VARCHAR(255) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NULL,
    created_by INT NOT NULL,
    updated_by INT NULL
);
