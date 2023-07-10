## Simple Logging Client

### Issue:

Logging can be a challenging task to standardize, especially for newer developers. Incorrectly logged information can result in missing items when troubleshooting. Additionally, logging operations can consume significant resources, potentially allocating up to 10% of the system's resources when parsing objects to be stored in a tabular database.

### Solution:

The Simple Logging Client offers a streamlined approach to logging, providing a consistent structure for various logging scenarios. It simplifies the process by creating a signature for different logging operations and offers the following capabilities:

**Application**:

- Log: For logging application-related events.
- Error: For logging application errors.

**External Transaction**:

- Transaction: For logging external transactions.
- Error: For logging errors in external transactions.

**Internal Transactions**:

- Transaction: For logging internal transactions within the application.
- Error: For logging errors in internal transactions.

**Message Queues**:

- Messages: For logging messages related to message queues.
- Error: For logging errors related to message queues.

**Relational Databases**:

- Transaction: For logging transactions in relational databases.
- Error: For logging errors related to relational databases.

### Design:

![Simple Logging Client Design](https://cgufeg.ch.files.1drv.com/y4mO_Yq_sKBabT4egaSlQdg5wMG1RBGXtv1UUwy-lW-oiVLg47dKLHRh5ippTsSFt1SOT4QZ6lQ0xNnXuvdzZ5byJ6DZV2Ga3oIO0GXBs21hAE2-CKPz8V_UBpc_k2TwSJDwNcXN9qUQtW0WeP25IvtWW5OIlOWhSQBq-xoNCXCU3sp400XwEgDPKifiEUJmkCs8oP2IZuNba9pwKKIDKPMrQ?width=1353&height=696&cropmode=none)

**Fig. 1. Simple Logging Client Design**. An application references SimpleLoggingClient and sets up the required queue information (Username/Password). Logging is handled as a single object to be used with dependency injection (DI). The log/error is sent to the designated queue. Another application, currently under development, will gather messages from the queue. The logic path for handling the messages will be determined by their type. The messages will then be divided into transactions and stored in the appropriate database tables.

The design follows a modular approach, allowing for scalability and flexibility in handling different logging scenarios. The Simple Logging Client acts as a bridge between the application and the logging infrastructure, ensuring standardized logging operations.

Please note that the separate application mentioned in the design is currently in development and will be responsible for processing and storing the logged messages from the queue.

