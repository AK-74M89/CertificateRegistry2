CREATE OR REPLACE FUNCTION public.organization_delete (
  id_organization integer
)
RETURNS integer AS
$body$
BEGIN
  DELETE FROM organization AS o
    WHERE o.id = $1;
  RETURN $1;
END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100;