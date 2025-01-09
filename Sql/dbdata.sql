INSERT INTO Brewery (name) VALUES
('Abbaye de Leffe'),
('Brasserie Dupont'),
('Bière de la Senne'),
('Chimay'),
('Brouwerij Westmalle');

INSERT INTO Brewer (brewery_id, name) VALUES
(1, 'Jean Lefevre'),
(2, 'Paul Dupont'),
(3, 'Pierre Senne'),
(4, 'Michel Chimay'),
(5, 'François Westmalle');

INSERT INTO Beer (name, alcohol_content, price, brewer_id) VALUES
('Leffe Blonde', 6.6, 2.20, 1),
('Leffe Brune', 6.2, 2.50, 1),
('Moinette Blonde', 8.5, 3.10, 2),
('Senne IPA', 7.0, 2.80, 3),
('Chimay Blue', 9.0, 3.50, 4),
('Westmalle Tripel', 9.5, 3.80, 5);

INSERT INTO Wholesaler (name) VALUES
('GeneDrinks'),
('BrewMaster'),
('Belgian Brewers Supply'),
('LeMarché Bières');

INSERT INTO WholesalerStock (wholesaler_id, beer_id, action, quantity) VALUES
(1, 1, 1, 10),
(1, 2, 1, 5),
(1, 2, 1, 15),
(1, 1, 0, 5),
(2, 3, 1, 20),
(2, 3, 1, 25),
(2, 3, 0, 30),
(2, 3, 0, 5);

INSERT INTO Orders (wholesaler_id) VALUES
(1),
(2),
(3),
(4);

INSERT INTO OrderDetails (order_id, beer_id, quantity) VALUES
(1, 1, 5),
(1, 2, 2),
(2, 3, 10),
(2, 4, 4),
(3, 5, 18),
(3, 6, 10),
(4, 1, 25),
(4, 5, 15);
