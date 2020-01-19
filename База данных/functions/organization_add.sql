CREATE OR REPLACE FUNCTION public.organization_add (
  name varchar
)
RETURNS integer AS
$body$
BEGIN
  INSERT INTO organization
    VALUES (DEFAULT, $1);
  RETURN currval('organization_id_seq'::regclass);
END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100;