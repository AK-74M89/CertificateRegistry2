CREATE OR REPLACE FUNCTION public.certificate_edit (
  id_certificate integer,
  certificate_name varchar,
  certificate_number varchar,
  certificate_date_begin date,
  certificate_date_end date,
  certificate_id_organization integer
)
RETURNS integer AS
$body$
BEGIN
  UPDATE certificate
    SET name = $2,
        number = $3,
        date_begin = $4,
        date_end = $5,
        id_organization = $6
    WHERE id = $1;
  RETURN $1;
END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100;