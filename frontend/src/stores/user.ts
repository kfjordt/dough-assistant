import { computed, ref } from 'vue';
import { defineStore } from 'pinia';
import { UserDto } from '../models/dto/UserDto';

export const displayLoginScreen = false;
export const useUserStore = defineStore('user', () => {
    const loggedInUser = ref<UserDto | null>(displayLoginScreen
        ? null
        : {
            userId: "111179186858378018776",
            name: "Kasper Jordt",
            email: "kfjordt@gmail.com"
        });

    const setLoggedInUser = (user: UserDto) => {
        loggedInUser.value = user
    }

    return {
        loggedInUserId: loggedInUser,
        setLoggedInUserId: setLoggedInUser
    };
});