CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

-- NOTE TABLE FOR RECIPES
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
-- 

-- NOTE CREATE RECIPES
INSERT INTO recipes
(name,picture,title,subtitle,category,creatorId)
VALUES
("Pumpkin Pie", "https://images.unsplash.com/photo-1570299882315-c4c41c78292c?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=774&q=80",
"Jons Famous Pumpkin Pie", "Fresh Pumpkin Pie", "Desert", "62f692c85d4c5d880f69ac3a");
-- 


SELECT * from recipes;
-- NOTE TABLE FOR STEPS
CREATE TABLE IF NOT EXISTS steps(
  position INT NOT NULL,
  body VARCHAR(255) NOT NULL,
  recipeId INT NOT NULL
) default charset utf8;
-- 



-- NOTE USE THIS TO CREATE STEPS
INSERT INTO steps
(position,body,recipeId)
VALUES
(6, "Eat", 1 );
-- 

SELECT * from steps;

-- NOTE TABLE FOR INGREDIENTS
CREATE TABLE IF NOT EXISTS ingredients(
  id INT AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(255) NOT NULL,
  quantity VARCHAR(255) NOT NULL DEFAULT 0,
  recipeId INT NOT NULL,

  FOREIGN KEY (recipeId) REFERENCES recipes(id)
) default charset utf8;
-- 
-- NOTE TABLE FOR STEPS
CREATE TABLE IF NOT EXISTS steps(
  id INT AUTO_INCREMENT PRIMARY KEY,
  position VARCHAR(255) NOT NULL,
  body VARCHAR(255) NOT NULL DEFAULT 0,
  recipeId INT NOT NULL,

  FOREIGN KEY (recipeId) REFERENCES recipes(id)
) default charset utf8;
-- 

-- NOTE USE THIS FOR INSERT INTO INGREDIENTS
INSERT INTO ingredients
(name,quantity,recipeId)
VALUES
("IDK", 1, 2);
-- 

-- NOTE SELECT ALL INGREDIENTS
SELECT * from ingredients i
JOIN recipes r ON r.id = i.recipeId ;
-- 

-- GETTING STEPS IN ORDER BY RECIPE ID
SELECT * from steps
WHERE recipeId = 1
ORDER BY position
;
-- 
