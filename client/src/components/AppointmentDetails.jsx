import { useEffect, useState } from "react"
import {  getAppointmentById } from "../data/appointmentData"
import { useParams } from "react-router-dom"




export const AppointmentDetails = () => {

    const [appointment, setAppointment] = useState([])
    const { id } = useParams()



    const getAndResetAppointment = () => {
        getAppointmentById(id).then(apptObject => {
            setAppointment(apptObject)
        })
    }

    useEffect(() => {
        getAndResetAppointment()
    }, [getAppointmentById])



    return (
        <>
            <h1>Appointment Details</h1>
            <div>
                <h2>Date:</h2>
                <h3>{new Date(appointment.time).toLocaleDateString()}</h3>
                <h2>Services:</h2>
                {appointment.services?.map(s => <h3 key={s.id}>{s.type}</h3>)}

                <h2>Customer:</h2>
                <h3>{appointment.customer?.name}</h3>
                <h2>Stylist:</h2>
                <h3>{appointment.stylist?.name}</h3>
                <button className="btn-primary">Edit Appointment</button>
            </div>
        </>
    )
}