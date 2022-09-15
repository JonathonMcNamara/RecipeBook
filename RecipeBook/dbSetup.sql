CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';


CREATE TABLE IF NOT EXISTS recipes(
  id INT AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(255) NOT NULL,
  picture VARCHAR(255) NOT NULL,
  title VARCHAR(255) NOT NULL, 
  subtitle VARCHAR(255) NOT NULL,
  category VARCHAR(255) NOT NULL,
  creatorId VARCHAR(255) NOT NULL,

  FOREIGN KEY (creatorId) REFERENCES accounts(id)
) default charset utf8;


INSERT INTO recipes
(name,picture,title,subtitle,category,creatorId)
VALUES
("Pumpkin Pie", "https://images.unsplash.com/photo-1570299882315-c4c41c78292c?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=774&q=80",
"Jons Famous Pumpkin Pie", "Fresh Pumpkin Pie", "Desert", "62f692c85d4c5d880f69ac3a");