CREATE OR REPLACE FUNCTION public.certificate_delete (
  id_certificate integer
)
RETURNS integer AS
$body$
BEGIN
  DELETE FROM certificate AS c
    WHERE c.id = $1;
  RETURN $1;
END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100;