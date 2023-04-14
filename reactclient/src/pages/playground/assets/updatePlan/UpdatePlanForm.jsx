import { useState } from "react";
import endpoints from '../../../../utilities/endpoints'
import './updateplanform.css'

import { GiCancel } from 'react-icons/gi'

export default function UpdatePlanForm(props) {
    const initialFormData = Object.freeze({
        name: props.plan.name,
        place: props.plan.place,
        startDate: formatDateString(props.plan.startDate),
        endDate: formatDateString(props.plan.endDate),
        addicionalInformation: props.plan.addicionalInformation
    });

    const [formData, setFormData] = useState(initialFormData);
    const [formErrors, setFormErrors] = useState({});
    
    const handleChange = (e) => {
        const { name, value } = e.target;

        if(name === 'startDate' || name === 'endDate'){
            const dateObject = new Date(value);

            // Format the date object into the desired format
            const formattedDate = `${dateObject.getFullYear()}-${(dateObject.getMonth() + 1).toString().padStart(2, '0')}-${dateObject.getDate().toString().padStart(2, '0')}`;

            setFormData({
                ...formData,
                [name]: formattedDate, 
            });

            
        } else {
            setFormData({
                ...formData,
                [name]: value, // name which is name equals to value input by user
            });
        }
        
    };

    const handleSubmit = (e) => {
        e.preventDefault(); // no reload we handle that

        const errors = {};
        let isValid = true;
        if (formData.name.trim() === "") {
            errors.name = "Name is required";
        }
        if (formData.place.trim() === "") {
            errors.place = "Place is required";
        }
        if (!formData.startDate) {
            errors.startDate = "Start date is required";
            isValid = false;
        }
        if (!formData.endDate) {
            errors.endDate = "End date is required";
            isValid = false;
        }
        setFormErrors(errors);

        const startDate = new Date(formData.startDate);
        const endDate = new Date(formData.endDate);

        // Compare the startDate and endDate values
        if (startDate > endDate) {
            errors.startDate = "Start date must be earlier than end date";
            isValid = false;
        }

        if (Object.keys(errors).length === 0) { 
            const planToUpdate = {
                name: formData.name,
                place: formData.place,
                startDate: formData.startDate,
                endDate: formData.endDate,
                addicionalInformation: formData.addicionalInformation
            };

            let urlBase = endpoints.API_UpdatePlan;
            let urlId = props.plan.id

            const url = urlBase.concat("/", urlId);
            
            fetch(url, 
                { 
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json' // necessary for sending json to api
                },
                body: JSON.stringify(planToUpdate)
                })
                .then(response => response.json())
                .then(responseFromServer => {
                })
                .catch((error) => {
                });
                
            props.onPlanUpdated(planToUpdate);
        }
    };

    return (
        <div className="card-update">
            <form className="card-update-form"> 
                <h1>Plan { props.plan.name }</h1>
                <div className="card-input-update">
                    <label>Name</label>
                    <input value={ formData.name } name="name" type="text" onChange={handleChange} required></input>
                    {formErrors.name && <p className="error">{formErrors.name}</p>}
                </div>
                <div className="card-input-update">
                    <label>Place</label>
                    <input value={ formData.place } name="place" type="text" onChange={handleChange} required></input>
                    {formErrors.place && <p className="error">{formErrors.place}</p>}
                </div>
                <div className="card-input-update">
                    <label>Start</label>
                    <input value={ formData.startDate } name="startDate" type="date" onChange={handleChange} required></input>
                    {formErrors.startDate && <p className="error">{formErrors.startDate}</p>}
                </div>
                <div className="card-input-update">
                    <label>End</label>
                    <input value={ formData.endDate } name="endDate" type="date" onChange={handleChange} required></input>
                    {formErrors.endDate && <p className="error">{formErrors.endDate}</p>}
                </div>
                <div className="card-input-update">
                    <label>Addicional Information</label>
                    <textarea value={ formData.addicionalInformation } name="addicionalInformation" type="text" rows="4" onChange={handleChange}></textarea>
                </div>
                <button onClick={handleSubmit} className="button-update">Update</button>
            </form>
            <button onClick={ () => props.onPlanUpdated(null)} className="button-cancel-update">
                <GiCancel />
            </button>
        </div>
    );

    function formatDateString(dataString){
        const date = dataString;
        const dateParts = date.split('/'); // Split the date string by '/'
        const dateFormatted = `${dateParts[2]}-${dateParts[1]}-${dateParts[0]}`; // Format the date as "YYYY-MM-DD"

        return dateFormatted;
    }
}