CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS restaurants (
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  name TEXT NOT NULL COMMENT 'name of the restaurant',
  category TEXT NOT NULL COMMENT 'The Category of restaurant (chineese, american, canadian)',
  address TEXT NOT NULL COMMENT 'THE ADDRESS DUMMY'
) default charset utf8 COMMENT '';

ALTER TABLE
  restaurants
ADD
  COLUMN picture VARCHAR(5000) DEFAULT "https://images.unsplash.com/photo-1484659619207-9165d119dafe?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=2070&q=80";


CREATE TABLE IF NOT EXISTS reviews (
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  rating INT NOT NULL COMMENT '1-5 RATING FOR REVIEW',
  body TEXT NOT NULL COMMENT 'The actual review',
  creatorId VARCHAR(255) NOT NULL,
  restaurantId INT NOT NULL, 

  FOREIGN KEY (creatorId)
    REFERENCES accounts(id)
    ON DELETE CASCADE,

  FOREIGN KEY (restaurantId)
    REFERENCES restaurants(id)
    ON DELETE CASCADE  

) default charset utf8 COMMENT '';


INSERT INTO reviews
(body, restaurantId, creatorId, rating)
VALUES
("Food was Meh", 5, "60d3560eceb6bbdfae388576", 3);



-- NOTE you dont need this for the final

SELECT 
  rs.*,
  AVG(rv.rating) AS AverageRating
FROM restaurants rs
LEFT JOIN reviews rv ON rv.restaurantId = rs.id
GROUP BY rs.id;
