import { computed, ref } from 'vue';
import { defineStore } from 'pinia';
import { UserDto } from '../models/dto/UserDto';
import { clientSecrets } from '../ClientSecrets';

export const useUserStore = defineStore('user', () => {
    const loggedInUserId = ref<string | null>(false ? null : clientSecrets.sampleUserId);

    const setLoggedInUserId = (userId: string) => {
        loggedInUserId.value = userId
    }

    return {
        loggedInUserId,
        setLoggedInUserId
    };
});