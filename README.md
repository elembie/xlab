# X-lab coding challenge | Find-A-Beer

This is a mono-repo containing code for infrastructure (docker-compose), api (.net core) and minimal frontend (react).

I attempted to show breadth of knowledge across the stack, due to time constraints it may have detracted from the completeness of each element (e.g. some code architecture in the API could be better decoupled and tested, the frontend has no styling etc).

## Running

The entire solution is detailed in the `docker-compose.yaml` file, as long as you have `docker` and `docker-compose` installed you can run from the root directory by;

```$ docker-compose build && docker-compose up```

Then navigate to `http://localhost:3000`.

The initial build might take a while but subsequent runs should be much faster once the images are cached.

## Approach

### Infrastructure

I attempted to demonstrate an example of a fully containerised infrastructure approach. I chose `docker-compse` for ease of local development and portability for the challenge. In a production environment this could be releativly easily shifted to a proper kubernetes base to provide easy production deployment, scaling etc.

Due to time constraints some of the connectivity is a bit hacky (e.g using the react dev server and proxying to the backend service over http) that would definitely not be present in a production solution.

### Data seeding

I used a side car container approach to provide data seeding from the csv file from a python script. The conatainer waits for the services to be ready and checks the database has migrated before importing. Again this probably wouldn't be used in a production setting and was more of a helper for this challenge.

### API

I kept the API as simple as possible but wanted to demonstrate use of EF core as code first for the database. As the only application logic was very simple the code is not very decoupled - if there was more application logic I would split out the domain logic into domain objects and provide increased unit testing. The testing is definitely lacking as most code is fairly boiler-plate .net and there's minimal application logic to test - but still this could be improved

### Front end

I wanted to demonstrate I can connect the React app to the backend and utilise redux for the API calls and shared application state. Due to time constraints there is no styling and all the redux state is in a single file.

## Shortcomings

- API code could be more decoupled and testable, and in any production setting test coverage would be much higher but I wanted to focus on the breadth of the challenge and ran out of time to complete more tests
- The front end has no styling
- The data seeding script is a little hacky and needs data integrity tests, however the approach really wouldn't be used in a production setting, it was more of a helper
