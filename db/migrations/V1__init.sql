create table users
(
    id uuid,
    name varchar not null,
    message varchar not null
);

create unique index users_id_uindex
    on users (id);

alter table users
    add constraint users_pk
        primary key (id);