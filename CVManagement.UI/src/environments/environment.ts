// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  apiEndpoint: 'https://localhost:5001',
  // adalConfig: {
  //   tenant: '46e8e6e1-41b7-4a3f-beb1-8c46a4d2895e',
  //   clientId: 'fae469bb-e2a4-42a8-b5ad-2223bdf0dcbc',
  //   endpoints: {
  //     'https://localhost:44347': 'fae469bb-e2a4-42a8-b5ad-2223bdf0dcbc'
  //   },
  //   redirectUri: window.location.origin,
  //   navigateToLoginRequestUrl: false
  // }
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
