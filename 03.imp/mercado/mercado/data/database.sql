CREATE TABLE [dbo].[categoria] (
    [id]          INT          IDENTITY (1, 1) NOT NULL,
    [descripcion] VARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[marca] (
    [id]          INT          IDENTITY (1, 1) NOT NULL,
    [descripcion] VARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[unidad] (
    [id]     CHAR (3)     NOT NULL,
    [nombre] VARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[producto] (
    [id]              INT            IDENTITY (1, 1) NOT NULL,
    [codigo]          VARCHAR (30)   NOT NULL,
    [cantidad_minima] NUMERIC (7, 2) NOT NULL,
    [precio]          NUMERIC (7, 2) NOT NULL,
    [descripcion]     VARCHAR (100)  NOT NULL,
    [unidad_id]       CHAR (3)       NOT NULL,
    [categoria_id]    INT            NOT NULL,
    [marca_id]        INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([unidad_id]) REFERENCES [dbo].[unidad] ([id]),
    FOREIGN KEY ([categoria_id]) REFERENCES [dbo].[categoria] ([id]),
    FOREIGN KEY ([marca_id]) REFERENCES [dbo].[marca] ([id])
);


