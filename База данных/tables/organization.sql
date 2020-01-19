CREATE TABLE public.organization (
  id SERIAL, 
  name VARCHAR(255) NOT NULL, 
  CONSTRAINT organization_pkey PRIMARY KEY(id)
) WITHOUT OIDS;

ALTER TABLE public.organization
  ALTER COLUMN id SET STATISTICS 0;

ALTER TABLE public.organization
  ALTER COLUMN name SET STATISTICS 0;