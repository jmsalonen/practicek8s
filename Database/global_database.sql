\c global

create table service_providers (
	id bigint generated always as identity primary key,
	name varchar(1000),
	hide_from_selection boolean default false not null
);

create table realms (
	name varchar(1000) not null primary key,
	service_provider_id bigint not null,
	constraint fk__realms__service_provider foreign key (service_provider_id) references service_providers (id) on delete cascade
);

create table users (
	id bigint generated always as identity primary key,
	username varchar(1000) not null,
	realm_name varchar(1000) not null,
	constraint fk__users__realm foreign key (realm_name) references realms (name) on delete cascade
);
