const API_BASE_URL_DEVELOPMENT = 'https://localhost:7212';
const API_BASE_URL_PRODUCTION = 'https://appname.azurewebsites.net';

const ENDPOINTS = {
    GetAllPlans: 'api/v1/plans',
    GetPlanById: 'api/v1/plans',
    CreatePlan: 'api/v1/plans',
    UpdatePlan: 'api/v1/plans',
    DeletePlan: 'api/v1/plans',
};

const Development = {
    API_GetAllPlans: `${ API_BASE_URL_DEVELOPMENT }/${ ENDPOINTS.GetAllPlans}`,
    API_GetPlanById: `${ API_BASE_URL_DEVELOPMENT }/${ ENDPOINTS.GetPlanById}`,
    API_CreatePlan: `${ API_BASE_URL_DEVELOPMENT }/${ ENDPOINTS.CreatePlan}`,
    API_UpdatePlan: `${ API_BASE_URL_DEVELOPMENT }/${ ENDPOINTS.UpdatePlan}`,
    API_DeletePlan: `${ API_BASE_URL_DEVELOPMENT }/${ ENDPOINTS.DeletePlan}`,
};

const Production = {
    API_GetAllPlans: `${ API_BASE_URL_PRODUCTION }/${ ENDPOINTS.GetAllPlans}`,
    API_GetPlanById: `${ API_BASE_URL_PRODUCTION }/${ ENDPOINTS.GetPlanById}`,
    API_CreatePlan: `${ API_BASE_URL_PRODUCTION }/${ ENDPOINTS.CreatePlan}`,
    API_UpdatePlan: `${ API_BASE_URL_PRODUCTION }/${ ENDPOINTS.UpdatePlan}`,
    API_DeletePlan: `${ API_BASE_URL_PRODUCTION }/${ ENDPOINTS.DeletePlan}`,
};

const Constants = process.env.NODE_ENV === 'development' ? Development : Production;

export default Constants;