CREATE OR REPLACE FUNCTION public.organization_get_all (
)
RETURNS TABLE (
  id_organization integer,
  organization_name varchar
) AS
$body$
BEGIN
  RETURN QUERY  SELECT o.id, o.name
                  FROM organization AS o;
END;
$body$
LANGUAGE 'plpgsql'
VOLATILE
CALLED ON NULL INPUT
SECURITY INVOKER
COST 100 ROWS 1000;