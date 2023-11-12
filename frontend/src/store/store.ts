import { reactive, readonly } from 'vue';
import { UserState } from './UserState';

const state = reactive({
    userState: new UserState(false)
});

const mutations = {
    setUserState(newUserState: UserState) {
        state.userState = newUserState
    }
};

const actions = {
    setCurrentlyLoggedInUser(email: string, bearerToken: string) {
        mutations.setUserState(
            new UserState(true, email, bearerToken)
        )
    },
    setUserToLoggedOut() {
        mutations.setUserState(
            new UserState(false)
        )
    }
};

// Create a read-only version of the state for external access
const store = readonly({
    state,
    mutations,
    actions,
});

export default store;
