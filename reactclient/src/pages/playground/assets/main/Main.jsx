import { useState, useEffect  } from 'react';
import endpoints from '../../../../utilities/endpoints'
import CreatePlanForm from '../createPlan/CreatePlanForm'
import UpdatePlanForm from '../updatePlan/UpdatePlanForm'
import "./main.css"

import Loader from '../loader/Loader'
import { AiOutlineEdit } from 'react-icons/ai'
import { AiOutlineDelete } from 'react-icons/ai'

export default function Main() {
  const [data, setData] = useState([]);
  const [showingCreateNewPlanForm, setShowingCreateNewPlanForm] = useState(false);
  const [planToBeUpdated, setPlanToBeUpdated] = useState(null);
  const [showLoader, setShowLoader] = useState(true);

  const GetPlans = () => {
    const url = endpoints.API_GetAllPlans;

    fetch(url, 
      { 
        method: 'GET'
      })
      .then(response => response.json())
      .then(PlansFromServer => {
        setData(PlansFromServer)
      })
      .catch((error) => {
      });

      data.map((data) => {
        data.startDate = new Date(data.startDate).toLocaleDateString('pt-PT');
        data.endDate = new Date(data.endDate).toLocaleDateString('pt-PT');
      });

  }

  useEffect(() => {
    setTimeout(() => {
      setShowLoader(false);
    }, 4000);
  }, []);

  return (
    <main >
      <section className="section-playground">
        { showLoader ? ( <Loader /> ) :
        <div>
          { ( showingCreateNewPlanForm === false && planToBeUpdated === null ) && (
            <div>
              { GetPlans() }
              <div className="button-group">
                <button onClick={ () => setShowingCreateNewPlanForm(true) } className="button-create">Create</button>
              </div>
            </div>
          )}
      
          { (data.length > 0 && showingCreateNewPlanForm === false && planToBeUpdated === null) && renderTable()}

          { showingCreateNewPlanForm && <CreatePlanForm onPlanCreated={ onPlanCreated }/>}

          { planToBeUpdated !== null && <UpdatePlanForm plan={ planToBeUpdated } onPlanUpdated={ onPlanUpdated } />}
        </div>
      }
      </section>
    </main>
  );

  function renderTable(){
    return (
        <div className="card">
          { data.map((data) => (
             <ul key={ data.id } className="card-list">
                <li>{ data.name }</li>
                <li>Place: { data.place }</li>
                <li>Start: { data.startDate } </li>
                <li>End: { data.endDate }</li>
                <li>Additional Information: { data.addicionalInformation }</li>
                <li className="card-buttons">
                  <button onClick={ () => setPlanToBeUpdated(data) } className="card-button">
                    <AiOutlineEdit />
                    </button>
                  <button onClick={ () => confirmPlanDelete(data.name, data.id)} className="card-button">
                    <AiOutlineDelete />
                  </button>
                </li>
              </ul>
          ))}
        </div>
    );
  }

  function onPlanCreated(createdPlan){
    setShowingCreateNewPlanForm(false);

    if(createdPlan === null){
      return;
    } 

    alert(`Post successfully created. After clicking OK, your new plan named "${ createdPlan.name }" will show up in the table below.`);

    GetPlans();
  }

  function onPlanUpdated(updatedPlan){
    setPlanToBeUpdated(null);

    if(updatedPlan === null){
      return;
    }

    let plansCopy = [...data];

    const index = plansCopy.findIndex((planToCopy, currentIndex) => {
      if(planToCopy.Id === updatedPlan.Id){
        return true;
      }
      return false;
    });
    
    if(index !== -1){
      plansCopy[index] = updatedPlan;
    }

    setData(plansCopy);

    alert(`Post successfully updated. After clicking OK, your new plan named "${ updatedPlan.name }" will show up updated in the table below.`);

    GetPlans();
  }

  function onPlanDeleted(planToDeleteId){

    let plansCopy = [...data];

    const index = plansCopy.findIndex((planToCopy, currentIndex) => {
      if(planToCopy.Id === planToDeleteId){
        return true;
      }
      return false;
    });
    
    if(index !== -1){
      plansCopy.splice(index, 1);
    }

    setData(plansCopy);

    alert(`Post successfully deleted. After clicking OK the table below will be updated without the plan.`);

    GetPlans();
  }

  function confirmPlanDelete(planName, id){
    if(window.confirm(`Are you sure you want to delete the plan ${ planName }?`)){
      deletePlan(id);
    }
  }

  function deletePlan(id){
    let urlBase = endpoints.API_DeletePlan;

    const url = urlBase.concat("/", id);

    fetch(url, 
      { 
        method: 'DELETE'
      })
      .then(response => response.json())
      .then(ResponseFromServer => {
        onPlanDeleted(id);
      })
      .catch((error) => {
      });
  }
}
