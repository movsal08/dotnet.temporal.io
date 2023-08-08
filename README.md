[![.NET](https://github.com/movsal08/dotnet.temporal.io/actions/workflows/dotnet.yml/badge.svg?branch=master)](https://github.com/movsal08/dotnet.temporal.io/actions/workflows/dotnet.yml)

# Temporal Workflow Management Demo
## Overview
The project is structured into several namespaces, each representing different aspects of the hotel booking and payment system:

- HotelApp: Simulates hotel room reservation and backup processes.
- PaymentApp: Simulates payment processing and backup operations.
- TicketApp: Simulates ticket reservation and backup operations.
- Temporal.Client: A client application that triggers the execution of workflows using Temporal.
- Temporal.Workflow: Contains workflow and activity implementations.
- BookRoomActivities: Defines activities for booking hotel rooms, tickets, and making payments.
- ShippingActivities: Defines an activity for shipping processes.
- BookRoomWorkflow: Defines a Temporal workflow for booking rooms and tickets, and making payments.
- ShippingWorkflow: Defines a Temporal workflow for shipping processes.
  
## How It Works
The project demonstrates the creation and execution of workflows using Temporal's programming model. It involves:

- Initiating workflows for booking rooms, tickets, and making payments.
- Performing activities such as room booking, ticket reservation, payment processing, and shipping.
- Managing workflow state and timeouts for different activities.
  
## Getting Started
You need to install temporal cluster before run this application.

The following steps will run a local instance of the Temporal Server using the default configuration file (`docker-compose.yml`):

1. Clone this repository.
2. Change directory into the root of the project.
3. Run the `docker-compose up` command.

```bash
git clone https://github.com/temporalio/docker-compose.git
cd  docker-compose
docker-compose up
```
- Clone this repository to your local machine.
- Install the Temporal CLI.
- Start the Temporal server using temporal start.
- Navigate to the Temporal.Workflow directory and run the Program.cs file to start the worker, which listens for and executes workflows and activities.
- Run the Temporal.Client program to trigger the execution of the workflows.

## Prerequisites
To use these files, you must first have the following installed:

- [Docker](https://docs.docker.com/engine/installation/)
- [docker-compose](https://docs.docker.com/compose/install/)

## Dependencies
- Temporal: An open-source workflow orchestration framework.
- .NET Core: The cross-platform framework used for building and running the C# code.
  
## Contributions
Contributions, bug reports, and feature requests are welcome! Feel free to open issues and submit pull requests.

## License
This project is licensed under the MIT License.

## Acknowledgments
This project is inspired by real-world workflow management scenarios and aims to provide an educational example of how Temporal can be used for orchestrating complex business processes.
