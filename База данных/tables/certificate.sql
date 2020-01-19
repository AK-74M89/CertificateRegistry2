CREATE TABLE public.certificate (
  id INTEGER DEFAULT nextval('certificates_id_seq'::regclass) NOT NULL, 
  name VARCHAR(255) NOT NULL, 
  number VARCHAR(255) NOT NULL, 
  date_begin DATE NOT NULL, 
  date_end DATE NOT NULL, 
  id_organization INTEGER NOT NULL, 
  CONSTRAINT certificate_pkey PRIMARY KEY(id), 
  CONSTRAINT certificate_organization_fk FOREIGN KEY (id_organization)
    REFERENCES public.organization(id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
    NOT DEFERRABLE
) WITHOUT OIDS;

ALTER TABLE public.certificate
  ALTER COLUMN id SET STATISTICS 0;

ALTER TABLE public.certificate
  ALTER COLUMN name SET STATISTICS 0;

ALTER TABLE public.certificate
  ALTER COLUMN number SET STATISTICS 0;

ALTER TABLE public.certificate
  ALTER COLUMN date_begin SET STATISTICS 0;

ALTER TABLE public.certificate
  ALTER COLUMN date_end SET STATISTICS 0;

ALTER TABLE public.certificate
  ALTER COLUMN id_organization SET STATISTICS 0;