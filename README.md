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


### Example `appsettings.json` configuration file:

```json
{
  "Logging": {
    // The name of your application
    "ApplicationName": "YourApplication",

    // The type of destination for logging (options: "Azure_Queue", "RabbitMq_Queue", "Azure_Service_Bus", "RabbitMq_Topic")
    "DestinationType": "Azure_Queue",

    // The log level for filtering log messages (options: "Trace", "Debug", "Information", "Warning", "Error", "Critical", "None")
    "LogLevel": "Information",

    // The connection string for the logging destination (e.g., Azure Queue Storage connection string)
    "ConnectionString": "your_connection_string",

    // The name of the queue for storing log messages
    "QueueName": "your_queue_name"

    // Additional configuration options for other destinations or features can be added here
  }
}
```

In this example, you can see the following configuration options:

- `"ApplicationName"`: The name of your application. You should replace `"YourApplication"` with the actual name of your application.

- `"DestinationType"`: The type of destination for logging. You can choose from the following options:
  - `"Azure_Queue"`: Azure Queue Storage
  - `"RabbitMq_Queue"`: RabbitMQ Queue
  - `"Azure_Service_Bus"`: Azure Service Bus
  - `"RabbitMq_Topic"`: RabbitMQ Topic

- `"LogLevel"`: The log level for filtering log messages. You can choose from the following options:
  - `"Trace"`
  - `"Debug"`
  - `"Information"`
  - `"Warning"`
  - `"Error"`
  - `"Critical"`
  - `"None"`

- `"ConnectionString"`: The connection string for the logging destination. This should be specific to the destination type you choose.

- `"QueueName"`: The name of the queue for storing log messages. Replace `"your_queue_name"` with the actual name of the queue.

You can add additional configuration options within the `"Logging"` section as per your requirements. These additional options can be specific to other destinations or features that you want to include in your logging library.

Remember to replace the placeholder values (`YourApplication`, `your_connection_string`, `your_queue_name`, etc.) with the actual values relevant to your application and logging configuration.
```

