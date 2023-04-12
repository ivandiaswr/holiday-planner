import "./main.css"
import welcomeIMG from "../../../../img/welcome.jpg"
import addIMG from "../../../../img/add.png"
import updateIMG from "../../../../img/update.png"
import deleteIMG from "../../../../img/delete.png"

import { Link } from "react-router-dom"

export default function Main() {
  return (
    <main>
        <section id="welcome" className="section-welcome">
          <div className="section-welcome-text">
            <h4>Plan your Dream Vacation today!</h4>
            <h2>Save big with the <strong>holiday</strong> management plataform</h2>
            
            <p>At my website, i make managing your vacations a breeze. Say goodbye to the hassle of keeping track of multiple vacations and their information, and track your well-deserved time off.
            With our user-friendly interface, you can easily create holidays view your upcoming vacations.</p>
            <p>Whether you're planning a relaxing getaway, a family vacation, or a special occasion, our platform simplifies the vacation management process, giving you more time to focus on what matters most – enjoying your time off.</p>
          </div>
          <div>
            <div className="section-welcome-img">
              <img src= {welcomeIMG} alt="welcome" title="Welcome"></img>
            </div>
            <button className="section-welcome-button"><Link to="/Playground">Demo here!</Link></button>
          </div>
          
        </section>
        
        <section id="funcionalities">
        <h1 className="titles">Funcionalities</h1>
        <div className="section-funcionalities">
          <div className="section-funcionalities-group">
            <div className="section-funcionalities-outter-img">
              <img src= {addIMG} alt="Create" title="Create" className="section-funcionalities-img"></img>
            </div>
            <h2>Create</h2>
            <p>The platform allows you to effortlessly create plans by providing a simple and intuitive process. You can specify plan details. Whether it's a personal goal or with a team, creating plans has never been easier.</p>
          </div>
          <div className="section-funcionalities-group">
            <div className="section-funcionalities-outter-img">
              <img src= {updateIMG} alt="Update" title="Update" className="section-funcionalities-img"></img>
            </div>  
            <h2>Update</h2>
            <p>Need to make changes to your plans? Our platform lets you update plans with ease. You can modify plan details. You can also add notes to keep yourself in the loop.</p>
          </div>
          <div className="section-funcionalities-group">
            <div className="section-funcionalities-outter-img">
              <img src= {deleteIMG} alt="Delete" title="Delete" className="section-funcionalities-img"></img>
            </div>
            <h2>Delete</h2>
            <p>If a plan is no longer relevant, the platform enables you to easily delete plans. You can choose to delete individual plans, ensuring your plan management is efficient and clutter-free.</p>
          </div>
          </div>
        </section>
        
        <section id="roadmap">
        <h1 className="titles">Roadmap</h1>
        <div className="section-roadmap">
          <div className="section-roadmap-group">
            <ul className="section-roadmap-list">
              <li className="section-roadmap-item">
                  <div className="section-roadmap-item-title">
                    <div className="section-roadmap-item-number">1</div>
                    <h3>User registration</h3>
                  </div>
                  <p>Implement a user registration feature on my website to enhance the user experience and provide personalized features. My app will allow, by user, to add new holidays, view their own list of holidays, update holiday details, and delete holidays from their list, all in a user-friendly and intuitive interface.</p>
              </li>
              <li className="section-roadmap-item">
                  <div className="section-roadmap-item-title">
                    <div className="section-roadmap-item-number">2</div>
                    <h3>Image implementation</h3>
                  </div>
                  <p>Implementing image support for plans, enhancing the visual experience for the users. With this exciting addition, users will be able to include images for each holiday in their list, making their holiday planning even more engaging and personalized.</p>
              </li>
              <li className="section-roadmap-item">
                  <div className="section-roadmap-item-title">
                    <div className="section-roadmap-item-number">3</div>
                    <h3>Design</h3>
                  </div>
                  <p>Design optimization to further enhance the user experience. I'm dedicated to continually improving my website's aesthetics and usability, ensuring that the users have a seamless and visually appealing experience. My goal is to create a visually pleasing and intuitive interface that is easy to navigate, allowing users to find the information they need quickly and efficiently.</p>
              </li>
            </ul>
            </div>
          </div>
        </section>
        
        <section id="contact" >
        <h1 className="titles">Contact</h1>
        <div className="section-contact">
            <div className="section-contact-info">
              <h2>Holiday management</h2>
              <p>Say goodbye to the hassle of keeping track of multiple vacations and their information, and track your well-deserved time off. With our user-friendly interface, you can easily create holidays view your upcoming vacations.</p>
              <h3>910616869</h3>
                <a href="mailto:ivandiasworkrelated@proton.me" alt="">
                  <i></i>
                  ivandiasworkrelated@proton.me
                </a>
            </div>
            <div className="section-contact-info">
              <h2>Company</h2>
              <a href="#">How we work</a>
              <a href="#">Careers</a>
              <a href="#">Mobile</a>
              <a href="#">Blog</a>
              <a href="#">Terms of use</a>
            </div>
            <div className="section-contact-info">
              <h2>Guides and resources</h2>
              <a href="#">Travel itinerary guides</a>
              <a href="#">Restaurants reservations by destination</a>
              <a href="#">Best places to visit by category</a>
              <a href="#">Popular search terms by destination</a>
              <a href="#">Weather around the world</a>
            </div>
          </div>
        </section>
    </main>
  );
}
