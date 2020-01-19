CREATE OR REPLACE FUNCTION public.certificate_get_registry (
)
RETURNS TABLE (
  id_certificate integer,
  certificate_name varchar,
  certificate_number varchar,
  certificate_date_begin date,
  certificate_date_end date,
  organization_name varchar
) AS
$body$
DECLARE
  certificates record;
  current_organization_name VARCHAR;
BEGIN
  DROP TABLE IF EXISTS certificate_registry;
  CREATE TEMP TABLE certificate_registry
  (
    id_certificate INTEGER,
    certificate_name VARCHAR(255),
    certificate_number VARCHAR(255),
    certificate_date_begin DATE,
    certificate_date_end DATE,
    organization_name VARCHAR(255)
  );
  
  FOR certificates IN SELECT * FROM certificate LOOP
    
    SELECT o.name
      INTO current_organization_name
      FROM organization AS o  
      WHERE o.id = certificates.id_organization;
      
    INSERT INTO certificate_registry
      VALUES (certificates.id, 
              certificates.name, 
              certificates.number, 
              certificates.date_begin,
              certificates.date_end,
              current_organization_name);
              
  END LOOP;
              
  RETURN QUERY SELECT * FROM certificate_registry;
END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100 ROWS 1000;