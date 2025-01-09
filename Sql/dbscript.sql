select * from beer 
    join brewer on beer.brewer_id = brewer.id_brewer
    join brewery on brewer.brewery_id = brewery.id_brewery;




SELECT 
    COALESCE(SUM(CASE WHEN action = 0 THEN -quantity ELSE quantity END), 0) AS stock_balance
FROM 
    WholesalerStock
WHERE 
    wholesaler_id = 1 AND beer_id = 2
    AND action_date >= (SELECT COALESCE(MAX(action_date), '1970-01-01') FROM WholesalerStock WHERE wholesaler_id = 1 AND beer_id = 2 AND action = 2)
;
