CREATE TABLE [Log] (
[ID] [int] IDENTITY (1, 1) NOT NULL ,
[Date] [datetime] NOT NULL ,
[Thread] [varchar] (100) COLLATE Chinese_PRC_CI_AS NULL ,
[Level] [varchar] (100) COLLATE Chinese_PRC_CI_AS NULL ,
[Logger] [varchar] (200) COLLATE Chinese_PRC_CI_AS NULL ,
[Operator] [int] NULL ,
[Message] [text] COLLATE Chinese_PRC_CI_AS NULL ,
[ActionType] [int] NULL ,
[Operand] [varchar] (300) COLLATE Chinese_PRC_CI_AS NULL ,
[IP] [varchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,
[MachineName] [varchar] (100) COLLATE Chinese_PRC_CI_AS NULL ,
[Browser] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
[Location] [text] COLLATE Chinese_PRC_CI_AS NULL ,
[Exception] [text] COLLATE Chinese_PRC_CI_AS NULL
)
