--
-- PostgreSQL database dump
--

-- Dumped from database version 13.2
-- Dumped by pg_dump version 13.2

-- Started on 2021-05-08 18:56:45

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 200 (class 1259 OID 16464)
-- Name: entitydevices; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.entitydevices (
    id bigint NOT NULL,
    user_id bigint NOT NULL,
    status character varying(10) NOT NULL,
    date character varying(10) NOT NULL
);


ALTER TABLE public.entitydevices OWNER TO postgres;

--
-- TOC entry 201 (class 1259 OID 16467)
-- Name: entitydevices_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.entitydevices_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.entitydevices_id_seq OWNER TO postgres;

--
-- TOC entry 3002 (class 0 OID 0)
-- Dependencies: 201
-- Name: entitydevices_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.entitydevices_id_seq OWNED BY public.entitydevices.id;


--
-- TOC entry 202 (class 1259 OID 16469)
-- Name: entityuser; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.entityuser (
    id bigint NOT NULL,
    name character varying(20) NOT NULL,
    status character varying(10) NOT NULL,
    role character varying(5) NOT NULL
);


ALTER TABLE public.entityuser OWNER TO postgres;

--
-- TOC entry 203 (class 1259 OID 16472)
-- Name: entityuser_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.entityuser_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.entityuser_id_seq OWNER TO postgres;

--
-- TOC entry 3003 (class 0 OID 0)
-- Dependencies: 203
-- Name: entityuser_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.entityuser_id_seq OWNED BY public.entityuser.id;


--
-- TOC entry 2856 (class 2604 OID 16474)
-- Name: entitydevices id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.entitydevices ALTER COLUMN id SET DEFAULT nextval('public.entitydevices_id_seq'::regclass);


--
-- TOC entry 2857 (class 2604 OID 16475)
-- Name: entityuser id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.entityuser ALTER COLUMN id SET DEFAULT nextval('public.entityuser_id_seq'::regclass);


--
-- TOC entry 2993 (class 0 OID 16464)
-- Dependencies: 200
-- Data for Name: entitydevices; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.entitydevices (id, user_id, status, date) VALUES (462, 4, 'inactive', '08.05.2021');
INSERT INTO public.entitydevices (id, user_id, status, date) VALUES (151, 5, 'inactive', '01.01.2021');
INSERT INTO public.entitydevices (id, user_id, status, date) VALUES (465, 4, 'inactive', '08.05.2021');
INSERT INTO public.entitydevices (id, user_id, status, date) VALUES (421, 6, 'inactive', '08.05.2021');
INSERT INTO public.entitydevices (id, user_id, status, date) VALUES (466, 4, 'inactive', '08.05.2021');
INSERT INTO public.entitydevices (id, user_id, status, date) VALUES (467, 5, 'inactive', '08.05.2021');
INSERT INTO public.entitydevices (id, user_id, status, date) VALUES (473, 16, 'inactive', '08.05.2021');
INSERT INTO public.entitydevices (id, user_id, status, date) VALUES (425, 6, 'inactive', '08.05.2021');
INSERT INTO public.entitydevices (id, user_id, status, date) VALUES (426, 6, 'inactive', '07.05.2021');
INSERT INTO public.entitydevices (id, user_id, status, date) VALUES (463, 4, 'inactive', '08.05.2021');
INSERT INTO public.entitydevices (id, user_id, status, date) VALUES (474, 16, 'active', '01.02.2021');
INSERT INTO public.entitydevices (id, user_id, status, date) VALUES (339, 5, 'inactive', '08.05.2021');
INSERT INTO public.entitydevices (id, user_id, status, date) VALUES (461, 4, 'inactive', '08.05.2021');
INSERT INTO public.entitydevices (id, user_id, status, date) VALUES (420, 6, 'inactive', '01.05.2021');
INSERT INTO public.entitydevices (id, user_id, status, date) VALUES (475, 6, 'inactive', '08.05.2021');
INSERT INTO public.entitydevices (id, user_id, status, date) VALUES (476, 6, 'inactive', '08.05.2021');
INSERT INTO public.entitydevices (id, user_id, status, date) VALUES (449, 4, 'inactive', '08.05.2021');


--
-- TOC entry 2995 (class 0 OID 16469)
-- Dependencies: 202
-- Data for Name: entityuser; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.entityuser (id, name, status, role) VALUES (4, 'Roman', 'free', 'admin');
INSERT INTO public.entityuser (id, name, status, role) VALUES (16, 'Alex', 'pro', 'admin');
INSERT INTO public.entityuser (id, name, status, role) VALUES (6, 'Pavel', 'base', 'user');
INSERT INTO public.entityuser (id, name, status, role) VALUES (5, 'Nikolay', 'base', 'user');


--
-- TOC entry 3004 (class 0 OID 0)
-- Dependencies: 201
-- Name: entitydevices_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.entitydevices_id_seq', 476, true);


--
-- TOC entry 3005 (class 0 OID 0)
-- Dependencies: 203
-- Name: entityuser_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.entityuser_id_seq', 16, true);


--
-- TOC entry 2859 (class 2606 OID 16477)
-- Name: entitydevices entitydevices_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.entitydevices
    ADD CONSTRAINT entitydevices_pkey PRIMARY KEY (id);


--
-- TOC entry 2861 (class 2606 OID 16479)
-- Name: entityuser entityuser_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.entityuser
    ADD CONSTRAINT entityuser_pkey PRIMARY KEY (id);


--
-- TOC entry 2862 (class 2606 OID 16480)
-- Name: entitydevices entitydevices_user_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.entitydevices
    ADD CONSTRAINT entitydevices_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.entityuser(id);


-- Completed on 2021-05-08 18:56:45

--
-- PostgreSQL database dump complete
--

