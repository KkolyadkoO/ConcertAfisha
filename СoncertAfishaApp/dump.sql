--
-- PostgreSQL database dump
--

-- Dumped from database version 16.0
-- Dumped by pg_dump version 16.9 (Homebrew)

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
-- Name: ConcertEntities; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."ConcertEntities" (
    "Id" uuid NOT NULL,
    "Title" text NOT NULL,
    "Description" text NOT NULL,
    "Date" timestamp with time zone NOT NULL,
    "LocationId" uuid NOT NULL,
    "Category" integer NOT NULL,
    "MaxNumberOfMembers" integer NOT NULL,
    "Price" numeric NOT NULL,
    "ImageUrl" text
);


ALTER TABLE public."ConcertEntities" OWNER TO postgres;

--
-- Name: LocationEntities; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."LocationEntities" (
    "Id" uuid NOT NULL,
    "Title" text NOT NULL,
    "Address" text NOT NULL,
    "City" text NOT NULL,
    "Lat" double precision DEFAULT 0.0 NOT NULL,
    "Lng" double precision DEFAULT 0.0 NOT NULL
);


ALTER TABLE public."LocationEntities" OWNER TO postgres;

--
-- Name: MemberEntities; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."MemberEntities" (
    "Id" uuid NOT NULL,
    "DateOfRegistration" timestamp with time zone NOT NULL,
    "Email" text NOT NULL,
    "Phone" text NOT NULL,
    "UserId" uuid NOT NULL,
    "ConcertId" uuid NOT NULL
);


ALTER TABLE public."MemberEntities" OWNER TO postgres;

--
-- Name: RefreshTokenEntities; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RefreshTokenEntities" (
    "Id" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "Token" text NOT NULL,
    "Expires" timestamp with time zone NOT NULL
);


ALTER TABLE public."RefreshTokenEntities" OWNER TO postgres;

--
-- Name: UserEntities; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."UserEntities" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "Lastname" text NOT NULL,
    "Phone" text NOT NULL,
    "UserEmail" text NOT NULL,
    "Password" text NOT NULL,
    "Role" text NOT NULL
);


ALTER TABLE public."UserEntities" OWNER TO postgres;

--
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- Data for Name: ConcertEntities; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."ConcertEntities" ("Id", "Title", "Description", "Date", "LocationId", "Category", "MaxNumberOfMembers", "Price", "ImageUrl") FROM stdin;
ca818838-4aec-4241-a070-9860ffc245f4	Music of Ludovico Einaudi	Продолжительность 1 час 30 минут\r\nЗнаменитый петербургский оркестр Imperial Orchestra представляет в Минске уникальное камерное шоу при свечах «Музыка Ludovico Einaudi».\r\n\r\nПрограмма посвящена музыкальному наследию Людовико Эйнауди — одного из самых видных представителей неоклассики. В век продвинутых технологий Эйнауди вспомнил об элегантности, которой наполнены произведения композиторов, живших много веков назад. Он смог совместить классические традиции с элементами поп, фолк и даже рок-музыки! Композиции композитора звучит буквально повсюду, а его альбомы бьют все рекорды продаж и получают мировое признание.\r\n\r\nЛюдовико создал неповторимые работы, которые с удивительной легкостью знакомят широкие аудитории с миром неоклассики, среди которых саундтреки к культовым фильмам: “1+1”, “Черный лебедь”, “Земля Кочевников” и многие другие.\r\n\r\nВ программе шоу представлены самые известные произведения автора, такие как: Experience, Una Mattina, Primavera, Fly и многие другие.\r\n\r\nМы приглашаем Вас погрузиться в утонченный мир знаменитого итальянского неоклассика Эйнауди! В сиянии тысячи свечей мы насладимся лучшими произведениями автора, а 10 блистательных солистов Imperial Orchestra проиллюстрируют все грани гения неоклассики.\r\n\r\n	2025-05-18 19:00:00+03	f9a627fd-d9fa-4154-b9b5-a726e47ecf16	4	700	130	/images/a0ef8461-9d70-4c1e-8633-4f17c0e14c60.jpeg
9f3274c7-5333-48ea-98f6-65f87947ed4e	Концерт группы Кипелов ''Весы судьбы''	Огненная энергия легендарного металла, мощный вокал Валерия Кипелова и бессмертные хиты, от которых дрожит земля!\r\n\r\nГруппа «Кипелов» возвращается с грандиозным концертом «Весы судьбы», чтобы вновь доказать: настоящий хэви-метал не стареет, а только набирает силу. В программе — культовые композиции из золотой эры «Арии», сольные хиты и новые треки, исполненные с фирменной мощью и страстью.	2025-05-15 19:00:00+03	f6c50d54-d3cf-4774-987c-81a8307c0292	1	300	120	/images/8a691c74-4ea0-465c-a1a6-c6a1bbe187f1.jpeg
e9d60520-abe3-47c5-9a91-2b0033f60abf	Алексей Горшенев	«Кукрыниксы» - одна из знаковых команд на российской рок-сцене, написавшая не один десяток хитов и композиций, которые живут в плейлистах слушателей. В 2024 году исполнилось 20 лет с выхода альбомов «Столкновение» и «Фаворит Солнца» - безусловно культовых для поклонников творчества «Кукрыниксов».\r\n\r\nИ праздновать такую дату нужно на сцене – Алексей Горшенев и музыканты проекта «Горшенев» сыграют специальный концерт 16 мая в 19:00 в Гродненской областной филармонии. В программу выступления войдут песни из этих двух альбомов в новых аранжировках и, конечно, главные хиты.\r\n\r\nДля многих фанатов знакомство с творчеством «Кукрыниксов» началось именно с альбома «Столкновение», который стал третьим по счету в дискографии группы. На пластинку вошло 13 композиций, записанных на студии «ДДТ» Алексеем Горшеневым и Дмитрием Гусевым – в текстах есть юмор, философия и мрачность, присущая команде. «Черная невеста», «Знай», «Серебряный сентябрь» - безусловные хиты, актуальные и сегодня.	2025-05-16 19:00:00+03	42b97555-625a-476b-b9ff-4d1187e5a46d	1	200	90	/images/1e586313-913f-4f19-b9ef-97be3605c201.jpeg
b64ba65a-66bb-4acb-8f71-5965be14a8bf	Симфония весны	Пробуждение природы, наполненное свежестью первых лучей, журчанием ручьев и пением птиц, сливается в гармоничную мелодию — "Симфонию весны". Это музыкальное произведение, словно сотканное из шепота листвы, теплого ветра и аромата цветущих садов, переносит слушателя в мир, где каждая нота — это капля дождя, а каждый аккорд — луч солнца, пробивающийся сквозь облака.	2025-06-07 12:00:00+03	42b97555-625a-476b-b9ff-4d1187e5a46d	2	300	33	/images/8834b37c-e571-43d5-83da-00af1d3aa835.jpeg
cc596840-7f4f-449a-ab65-a7f4af3934ff	Игра любви (16+)	Эта история французского писателя Пьера Мариво, написанная в XVIII веке, о любви и о вечном конфликте отцов и детей. В основе сюжета известный комедийный приём с переодеваниями слуг в хозяев и наоборот.\r\n\r\nОтец Сильвии господин Оргон узнает, что к нему в дом едет сын его старого друга для того, чтобы познакомиться с его дочерью. Сильвия, желая лучше узнать Доранта, решает поменяться местами со своей служанкой Лизеттой. Но тщательно продуманному плану Сильвии не удаётся сбыться, так как и Дорант меняется местами со своим слугой — Арлекином. Начинаются неразбериха, путаница и враньё, персонажи попадают в неловкие и смешные ситуации. Героям приходится отказываться от своих принципов и привычек, но всё разрешается благополучно, ведь настоящая любовь побеждает любые трудности и совсем неважно, кто ты – господин или слуга.\r\n\r\nМузыкальная комедия "Игра любви", поставленная заслуженным артистом Республики Татарстан, лауреатом Государственной премии Российской Федерации Маратом Башаровым, несомненно, привлечёт многочисленных любителей этого жанра. Ведь кроме прекрасной музыки и стихов Юлия Кима и виртуозной игры ведущих артистов Музыкального театра, спектакль наполнен смешными ситуациями и искромётным юмором.	2025-05-22 19:00:00+03	c4c8c78d-b598-48d4-a2e0-04f0d808857a	4	250	51	/images/3e717453-e5ff-4c3f-824e-8140925d5f6d.jpeg
2ca14100-3057-4b9a-855f-49b0ea85aa4a	КОНЦЕРТ группы РУКИ ВВЕРХ!	Ну, где же вы девчонки? И мальчишки!\r\n\r\nЛегендарная группа «Руки Вверх !» и Сергей Жуков скоро в Минске!\r\n\r\nМы вновь подарим вам романтику встреч, где он тебя целует и говорит, что любит, где студент игрушку новую нашёл, а по широкой тропе проскакали ковбои.\r\n\r\n18 вам уже, а значит, можно оторваться не по-детски под любимые хиты.\r\n\r\nГруппа «Руки Вверх !» собирает огромные залы по всей России. Присоединяйтесь к счастливым людям!\r\n\r\nОбещаем, этот вечер вы не забудете!\r\n\r\nКрошки мои, мы по вам скучаем! И ждём 30, 31 мая и 2 июня на большом концерте группы «Руки Вверх!» в Минске в Минск-арене.\r\n\r\nПриобретайте билеты заранее, чтобы чужие губы не шептали потом, как это было хорошо.	2025-05-31 17:00:00+03	f9a627fd-d9fa-4154-b9b5-a726e47ecf16	1	700	120	/images/2c84cf26-104a-49ec-94b1-b9780f20827b.jpeg
396950cc-dbf1-41a0-8222-e110ec8908b3	СИНЕМА МЭДЛИ (CINEMA MEDLEY)	Imperial Orchestra снова в Минске! Встречайте легендарное шоу саундтреков Cinema Medley! \r\n \r\nПрограмма:\r\n 1 Интерстеллар\r\n 2 Пираты Карибского моря\r\n 3 Игра престолов \r\n 4 Гладиатор\r\n 5 Начало\r\n 6 Бэтмен \r\n 7 Звёздные войны\r\n 8 Гарри Поттер\r\n 9 Список Шиндлера\r\n 10 Парк Юрского периода\r\n 11 Адажио Ре минор\r\n 12 Призрак оперы\r\n 13 Три товарища \r\n 14 Шерлок Холмс\r\n 15 Унесенные призраками\r\n 16 Ла Ла Лэнд\r\n \r\nCinema Medley – знаменитые саундтреки в исполнении большого симфонического оркестра Imperial Orchestra, органа и звёздных солистов Санкт-Петербурга и Москвы под управлением дирижёра Льва Дунаева!\r\nБолее 300 тысяч восторженных зрителей уже побывали на шоу, свыше миллиона просмотров трансляции концерта в интернете (и миллиарда мурашек по всему миру), а география концертов Imperial Orchestra от Санкт-Петербурга до Дубая! Вас ждут незабываемые эмоции в новом современном формате симфонического шоу!\r\n \r\nХанс Циммер, Джон Уильямс, Дэвид Арнольд, Рамин Джавади, Эндрю Ллойд Уэббер – всё это имена современных классиков, которые создают главные саундтреки XX и XXI века. Их музыка – не просто сопровождение фильмов, а целый симфонический мир, который завораживает, погружает в атмосферу кино, передаёт все переживания героев экрана и запоминается навсегда. В фильмах мы слышим различные темы, разбросанные по всей ленте, но как же хочется насладиться ими целиком, да ещё и в живом исполнении большого симфонического оркестра!\r\n \r\nМечтали ли вы услышать знаменитую заглавную тему из «Звёздных войн» или «Имперский марш»? Отправиться в музыкальный мир «Пиратов Карибского моря», побывать на «Чёрной жемчужине» с капитаном Джеком Воробьём или услышать орган Дэви Джонса? Может быть, Вас притягивает космический «Интерстеллар», волшебный мир «Гарри Поттера», или Вы предпочитаете захватывающую «Игру престолов»?\r\n \r\nМы собрали главные саундтреки XX и XXI века: \r\n«Шерлок Холмс», «Пираты Карибского моря», «Звёздные войны», «Гарри Поттер», «Интерстеллар», «Игра престолов», «Бэтмен», «Гладиатор», «Пекло», «Призрак оперы», «Парк Юрского периода», «Начало», «Список Шиндлера» и мн. др. Отобрали лучшие музыкальные темы и объединили их в уникальные симфонические сюиты – Medley.\r\n \r\nCinema Medley – это уникальный проект, не имеющий аналогов в мире! Imperial Orchestra выступает в формате 360, что позволяет каждому зрителю насладиться прекрасным мощным симфоническим звучанием и отличным обзором с любого места арены. \r\n\r\nЯркое световое шоу, 125 квадратных метров Led-экранов, 85 виртуозных музыкантов на одной сцене, музыку сразу из 16 фильмов в один вечер, фантастические аранжировки и эмоции, которые запомнятся навсегда!	2025-06-07 19:00:00+03	f9a627fd-d9fa-4154-b9b5-a726e47ecf16	4	700	150	/images/9dd481b7-d87f-4ee6-8d1a-282ac33814d7.jpeg
40537712-0a30-45ea-b830-89ae566ba494	 Эпик рок-шоу ''ROCK XXI Век'' (16+)	Рок-оркестр NIKAMUZA возвращается в Беларусь с концертами и, как всегда, это будет грандиозный взрыв эмоций, энергии и настоящего рока!	2025-06-01 19:00:00+03	42b97555-625a-476b-b9ff-4d1187e5a46d	1	300	95	/images/e10d36c2-33ff-420b-a1ca-8c61690a7fbb.jpeg
59e0b3f4-b61c-4037-a68e-ee1de2375f96	 Концерт Симфонического оркестра ''Красная Капелла'' с программой ''Симфония Мирового кино''	КРАСНАЯ КАПЕЛЛА возвращается! После аншлагового февральского тура оркестр представляет обновлённую программу «СИМФОНИЯ МИРОВОГО КИНО», в которую войдут как всегда лучшие саундтреки мирового киноискусства. 	2025-05-29 19:00:00+03	04e46304-3c87-469a-858a-e3a5c0853188	4	400	135	/images/d98f3a99-9a4a-47a9-bc7e-875565154f1e.jpeg
d482787e-7daf-4f14-a6b5-142d8fafe221	ГУФ	Прощальный концерт рэпера GUF в Минске!\r\n\r\n7 июня 2025 года на сцене Falcon Arena в Минске пройдет прощальный концерт легендарного артиста!	2025-06-07 20:00:00+03	bffcded2-fbc5-4726-9866-52f23caed060	5	500	207	/images/b904e92c-dc84-4888-995f-2fb962d0d9ca.jpeg
f826348e-e01b-4aec-a8bc-7e7649750b27	YANIX	Минск, встречай: большой сольный концерт YANIX, приуроченный к презентации нового альбома – Falcon Club 08 июня 2025г!\r\n\r\nАртист исполнит свежие треки из новой пластинки, а также подарит зрителям возможность вновь услышать культовые хиты, которые уже покорили сердца миллионов поклонников.	2025-06-08 20:00:00+03	bffcded2-fbc5-4726-9866-52f23caed060	5	500	207	/images/620110ad-68d1-4d47-acf6-349e7d3b3fdd.jpeg
8fcc2b71-815f-44cb-83f9-bf17c00227ff	А может, не было войны	Партия фортепиано – лауреат международных конкурсов Анастасия Дубовская 	2025-05-16 19:30:00+03	c4c8c78d-b598-48d4-a2e0-04f0d808857a	3	150	35	/images/0ba02eb8-85f6-46ee-a21d-2053ed3eaedd.jpeg
db88967f-26ed-4135-810f-e2f7bc3c918e	ContraBass-LIVE. Дыхание весны	Исполнители: лауреаты международных конкурсов Павел Приемка, Владимир Пуленков, Владислав Сеноженский, Михаил Сандронов, Мария Барановская (скрипка), Ольга Федоринчик (скрипка)\r\n\r\n	2025-05-23 19:30:00+03	c4c8c78d-b598-48d4-a2e0-04f0d808857a	3	150	35	/images/97fba44d-f45d-4264-91c6-b6804c0d75dc.jpeg
fa799c54-0ead-4384-b8b8-10c037bf11a9	Новое дыхание	Исполнители: брасс-квинтет "A.M.A.D.I.S. Brass"	2025-05-28 19:30:00+03	c4c8c78d-b598-48d4-a2e0-04f0d808857a	3	200	30	/images/41a9c876-c5bd-4d1d-aeef-36415b5bacd6.jpeg
2bfa752f-06a4-4a2f-9028-b7fffdc4894f	Три дня дождя	Большой концерт Три дня дождя, на котором вы сможете снова прожить все музыкальные эры вместе с артистом и пережить падения и взлеты!	2025-05-17 16:00:00+03	04e46304-3c87-469a-858a-e3a5c0853188	0	500	150	/images/ae0a26a3-89b6-42c6-a474-f2ffaad6c6bf.jpeg
ff02ff45-85ad-4a92-8195-726ae512e771	Friendly Thug 52 Ngg	Минск, встречай 30 мая состоится долгожданный концерт одного из самых ярких и уникальных представителей русскоязычной рэп-сцены — Friendly Thug 52 Ngg. \r\n\r\nВечер обещает быть насыщенным, с мощным звучанием и глубокими текстами, которые затрагивают актуальные темы и философию улиц.\r\n\r\nТрэп-музыка в исполнении Friendly Thug 52 Ngg — это не просто музыка, это отражение реальности, неподвластной времени, с прямыми, честными и порой жестокими словами. Его концерты всегда становятся настоящим событием для тех, кто ценит искренность и силу слова.	2025-05-30 17:00:00+03	bffcded2-fbc5-4726-9866-52f23caed060	6	350	210	/images/0c565320-8a74-45c0-ae6f-3cd41b006cd9.jpeg
8fd92108-9a64-45fa-93bc-c6ab1170d6ff	СИНАТРА - 110	Одним из самых ярких и интересных музыкальных событий в культурной жизни Беларуси является летний фестиваль джаза «Джаз в городе Н». Которыйтрадиционно пройдет в самом историческом месте нашей страны – в городе Несвиж во дворе замка Радзивиллов под открытым небом.\r\n\r\n	2025-07-05 20:00:00+03	c4c8c78d-b598-48d4-a2e0-04f0d808857a	7	350	40	/images/d2b87824-37d6-41b9-a02f-00b70b6cfbe2.jpeg
\.


--
-- Data for Name: LocationEntities; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."LocationEntities" ("Id", "Title", "Address", "City", "Lat", "Lng") FROM stdin;
42b97555-625a-476b-b9ff-4d1187e5a46d	Гродненская областная филармония	ул. Горновых, 17	Гродно	53.677498079651826	23.830760516418685
c4c8c78d-b598-48d4-a2e0-04f0d808857a	Белорусский гос. музыкальный театр	ул. Мясникова, 44	Минск	53.89590149387684	27.539699599375872
f9a627fd-d9fa-4154-b9b5-a726e47ecf16	Минск-Арена	проспект Победителей, 111	Минск	53.93503773876176	27.482386863761214
f6c50d54-d3cf-4774-987c-81a8307c0292	Дворец Спорта ''Виктория''	ул.Ленинградская, 4	Брест	52.09557828892796	23.697185949158325
bffcded2-fbc5-4726-9866-52f23caed060	Falcon Club Arena	просп. Победителей 20	Минск	53.933412893291084	27.50830574206674
04e46304-3c87-469a-858a-e3a5c0853188	Дворец спорта	пр. Победителей, 4	Минск	53.91065011813772	27.549687712619676
\.


--
-- Data for Name: MemberEntities; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."MemberEntities" ("Id", "DateOfRegistration", "Email", "Phone", "UserId", "ConcertId") FROM stdin;
\.


--
-- Data for Name: RefreshTokenEntities; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."RefreshTokenEntities" ("Id", "UserId", "Token", "Expires") FROM stdin;
9a8d9591-08b8-4e95-bd08-b5db00886596	1f9d1f64-0ed3-419d-8abd-9e09e84730a2	qGQIMxw/qoqouW6it1xkoEIedPwD4HpyCsylHgNtBh00OYRTEmNCQOz0SBesJRzLZqyo4rigelP0GddVL/Xfhw==	2025-05-19 10:27:06.31924+03
\.


--
-- Data for Name: UserEntities; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."UserEntities" ("Id", "Name", "Lastname", "Phone", "UserEmail", "Password", "Role") FROM stdin;
921219b3-c914-4f12-9317-891f18966eaf	Артём	Колядкоjjj	artem.7ko52@gmail.com	+375259039308	$2a$11$UAEcWeqopJcNur89uef3HuBUKZLCWLwYyBXy0eN3jzo2Aj0tapbu2	user
1f9d1f64-0ed3-419d-8abd-9e09e84730a2	Admin	Admin	+375259039308	artem.7ko52@gmail.com	$2a$11$VHucEIeKyAPK/EwGeTmklef3RAIPeUlnIjy.gDeq1I43YcXGKkqZ2	Admin
\.


--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20250505093110_init	9.0.2
20250512072540_ConcertFinish	9.0.2
\.


--
-- Name: ConcertEntities PK_ConcertEntities; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ConcertEntities"
    ADD CONSTRAINT "PK_ConcertEntities" PRIMARY KEY ("Id");


--
-- Name: LocationEntities PK_LocationEntities; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."LocationEntities"
    ADD CONSTRAINT "PK_LocationEntities" PRIMARY KEY ("Id");


--
-- Name: MemberEntities PK_MemberEntities; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."MemberEntities"
    ADD CONSTRAINT "PK_MemberEntities" PRIMARY KEY ("Id");


--
-- Name: RefreshTokenEntities PK_RefreshTokenEntities; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RefreshTokenEntities"
    ADD CONSTRAINT "PK_RefreshTokenEntities" PRIMARY KEY ("Id");


--
-- Name: UserEntities PK_UserEntities; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserEntities"
    ADD CONSTRAINT "PK_UserEntities" PRIMARY KEY ("Id");


--
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- Name: IX_ConcertEntities_LocationId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_ConcertEntities_LocationId" ON public."ConcertEntities" USING btree ("LocationId");


--
-- Name: IX_LocationEntities_Title; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "IX_LocationEntities_Title" ON public."LocationEntities" USING btree ("Title");


--
-- Name: IX_MemberEntities_ConcertId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_MemberEntities_ConcertId" ON public."MemberEntities" USING btree ("ConcertId");


--
-- Name: IX_MemberEntities_UserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_MemberEntities_UserId" ON public."MemberEntities" USING btree ("UserId");


--
-- Name: IX_RefreshTokenEntities_UserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_RefreshTokenEntities_UserId" ON public."RefreshTokenEntities" USING btree ("UserId");


--
-- Name: IX_UserEntities_Phone; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "IX_UserEntities_Phone" ON public."UserEntities" USING btree ("Phone");


--
-- Name: IX_UserEntities_UserEmail; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "IX_UserEntities_UserEmail" ON public."UserEntities" USING btree ("UserEmail");


--
-- Name: ConcertEntities FK_ConcertEntities_LocationEntities_LocationId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."ConcertEntities"
    ADD CONSTRAINT "FK_ConcertEntities_LocationEntities_LocationId" FOREIGN KEY ("LocationId") REFERENCES public."LocationEntities"("Id") ON DELETE CASCADE;


--
-- Name: MemberEntities FK_MemberEntities_ConcertEntities_ConcertId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."MemberEntities"
    ADD CONSTRAINT "FK_MemberEntities_ConcertEntities_ConcertId" FOREIGN KEY ("ConcertId") REFERENCES public."ConcertEntities"("Id") ON DELETE CASCADE;


--
-- Name: MemberEntities FK_MemberEntities_UserEntities_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."MemberEntities"
    ADD CONSTRAINT "FK_MemberEntities_UserEntities_UserId" FOREIGN KEY ("UserId") REFERENCES public."UserEntities"("Id") ON DELETE CASCADE;


--
-- Name: RefreshTokenEntities FK_RefreshTokenEntities_UserEntities_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RefreshTokenEntities"
    ADD CONSTRAINT "FK_RefreshTokenEntities_UserEntities_UserId" FOREIGN KEY ("UserId") REFERENCES public."UserEntities"("Id") ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

