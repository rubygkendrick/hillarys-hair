const _apiUrl = "/api/appointments";



export const getAllAppointments = () => {
    return fetch(_apiUrl).then((r) => r.json());
}

export const getAppointmentById = (id) => {
    return fetch(`${_apiUrl}/${id}`).then((r) => r.json());
}
