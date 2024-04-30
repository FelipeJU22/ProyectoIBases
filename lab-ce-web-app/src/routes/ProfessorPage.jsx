import ProfessorHeader from "../components/ProfessorHeader";
import ProfessorPanel from "../components/ProfessorPanel";
import ProfessorBody from "../components/ProfessorBody";
import classes from './ProfessorPage.module.css'

function ProfessroPage() {

    return<>
        <section className={classes.app}>
            <ProfessorHeader/>
            <div className={classes.main}>
                <div className={classes.leftPanel}>
                    <ProfessorPanel/>
                </div>
                <div className={classes.body}>
                    <ProfessorBody/>
                </div>

            </div>
        </section>
    </>

}

export default ProfessroPage;