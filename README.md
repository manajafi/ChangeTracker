# ChangeTracker

# What is a temporal table?
Temporal tables are a functionality of Microsoft SQL Server that allows you to record and manage the history of data. This allows you to track changes and retrieve previous versions of the data. A temporal table is essentially a conventional table that has an integrated system versioning mechanism. This mechanism automatically records changes to the data and saves a history of these changes.

The way temporal tables work is that two additional columns are added to the table: a start time and an end time. The start time indicates when a row was created or updated, while the end time marks the time at which the row was changed or deleted. When data is changed, new versions of the rows are created and saved in the table. At the same time, previous versions of the rows are given an end timestamp.

By using temporal tables, you can easily track changes to the data over time. This includes not only the ability to see who made a change, but also the time of the change. You can also query the table to retrieve the data status at a specific point in time. This allows you to easily analyze trends and patterns in the data.

# How does the version table work?
Versioning over time is implemented in the system using a pair of tables, one representing the current table and the other a history table. Within these tables, two additional datetime2 columns are used to define the validity period for each row:

System period start column: Here the system records the start of the row, usually referred to as the PeriodStart column.
System period end column: The system records the end date for the row in this column, usually referred to as the PeriodEnd column.
The current table holds the current value for each row. The history table holds any previous value (old version) for each row, if any. It also records the start and end of the period in which it was valid.