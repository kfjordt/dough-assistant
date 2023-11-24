import { computed, ref } from 'vue';
import { defineStore } from 'pinia';
import { UserDto } from '../models/dto/UserDto';
import { clientSecrets } from '../ClientSecrets';

export const useUserStore = defineStore('user', () => {
    const loggedInUser = ref<UserDto | null>(true ? null : clientSecrets.sampleUser);

    const setLoggedInUser = (user: UserDto) => {
        loggedInUser.value = user
    }

    return {
        loggedInUserId: loggedInUser,
        setLoggedInUserId: setLoggedInUser
    };
});