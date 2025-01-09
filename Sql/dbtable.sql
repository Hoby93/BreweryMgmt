-- brewerymgmt

CREATE TABLE Brewery (
    id_brewery SERIAL PRIMARY KEY,
    name VARCHAR(120) NOT NULL
);

CREATE TABLE Brewer (
    id_brewer SERIAL PRIMARY KEY,
    brewery_id  INT NOT NULL,
    name VARCHAR(120) NOT NULL,
    FOREIGN KEY (brewery_id) REFERENCES brewery(id_brewery)
);

CREATE TABLE Beer (
    id_beer SERIAL PRIMARY KEY,
    name VARCHAR(120) NOT NULL,
    alcohol_content DECIMAL(5, 2) NOT NULL,
    price DECIMAL(10, 2) NOT NULL,     
    brewer_id INT NOT NULL,
    FOREIGN KEY (brewer_id) REFERENCES brewer(id_brewer)
);

CREATE TABLE Wholesaler (
    id_wholesaler SERIAL PRIMARY KEY,
    Name VARCHAR(120) NOT NULL
);

CREATE TABLE WholesalerStock (
    id_wss SERIAL PRIMARY KEY,
    wholesaler_id INT NOT NULL,
    beer_id INT NOT NULL,
    action INT NOT NULL DEFAULT 0, -- Out:0, In:1, Rep:2
    quantity INT NOT NULL DEFAULT 0,
    action_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Date de la mvt
    FOREIGN KEY (wholesaler_id) REFERENCES wholesaler(id_wholesaler),
    FOREIGN KEY (beer_id) REFERENCES Beer(id_beer)
);

CREATE TABLE Orders (
    id_order SERIAL PRIMARY KEY,
    wholesaler_id INT NOT NULL,
    order_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP, -- Date de la commande
    FOREIGN KEY (wholesaler_id) REFERENCES wholesaler(id_wholesaler)
);

CREATE TABLE OrderDetails (
    id_od SERIAL PRIMARY KEY,
    order_id INT NOT NULL,
    beer_id INT NOT NULL,
    quantity INT NOT NULL, -- Quantité commandée
    FOREIGN KEY (order_id) REFERENCES Orders(id_order),
    FOREIGN KEY (beer_id) REFERENCES Beer(id_beer)
);