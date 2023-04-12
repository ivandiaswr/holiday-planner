import { useState } from "react";
import endpoints from '../../../../utilities/endpoints'
import './createplanform.css'

import { GiCancel } from 'react-icons/gi'

export default function CreatePlanForm(props) {
    const initialFormData = Object.freeze({
        name: "",
        place: "",
        startDate: null,
        endDate: null,
        addicionalInformation: ""
    });

    const [formData, setFormData] = useState(initialFormData);
    const [formErrors, setFormErrors] = useState({});
    
    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value, // name with is name equals to value input by user
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault(); // no reload we handle that

        // Form validation
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

            const planToCreate = {
                name: formData.name,
                place: formData.place,
                startDate: formData.startDate,
                endDate: formData.endDate,
                addicionalInformation: formData.addicionalInformation
            }    

            const url = endpoints.API_CreatePlan;

            fetch(url, 
                { 
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json' // necessary for sending json to api
                },
                body: JSON.stringify(planToCreate)
                })
                .then(response => response.json())
                .then(ResponseFromServer => {
                })
                .catch((error) => {
                });

            props.onPlanCreated(planToCreate);
        }
    };

    return (
        <div className="card-create">
            <form className="card-create-form">
                <h1>Plan</h1>
                <div className="card-input-create">
                    <label>Name</label>
                    <input value={ formData.name } name="name" type="text" className="" onChange={handleChange} required></input>
                    {formErrors.name && <p className="error">{formErrors.name}</p>}
                </div>
                <div className="card-input-create">
                    <label>Place</label>
                    <input value={ formData.place } name="place" type="text" className="" onChange={handleChange} required></input>
                    {formErrors.place && <p className="error">{formErrors.place}</p>}
                </div>
                <div className="card-input-create">
                    <label>Start</label>
                    <input value={ formData.startDate } name="startDate" type="date" className="" onChange={handleChange} required></input>
                    {formErrors.startDate && <p className="error">{formErrors.startDate}</p>}
                </div>
                <div className="card-input-create">
                <label>End</label>
                    <input value={ formData.endDate } name="endDate" type="date" className="" onChange={handleChange} required></input>
                    {formErrors.endDate && <p className="error">{formErrors.endDate}</p>}
                </div>
                <div className="card-input-create">
                    <label>Addicional Information</label>
                    <textarea value={ formData.addicionalInformation } name="addicionalInformation" type="text" rows="4" onChange={handleChange}></textarea>
                </div>
                <button onClick={handleSubmit} className="button-create">Create</button>
            </form>
            <button onClick={() => props.onPlanCreated(null)} className="button-cancel-create">
                <GiCancel />
            </button>
        </div>
    );
}