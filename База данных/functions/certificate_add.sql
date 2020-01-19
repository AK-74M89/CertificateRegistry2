CREATE OR REPLACE FUNCTION public.certificate_add (
  name varchar,
  number varchar,
  date_begin date,
  date_end date,
  id_organization integer
)
RETURNS integer AS
$body$
BEGIN
  INSERT INTO certificate
    VALUES (DEFAULT, $1, $2, $3, $4, $5);
  RETURN currval('certificates_id_seq'::regclass);
END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100;