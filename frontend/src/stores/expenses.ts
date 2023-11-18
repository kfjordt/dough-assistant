import { defineStore } from 'pinia';
import { ref } from 'vue';
import { Expense } from '../models/data/Expense';
import { ApiService } from '../api/ApiService';
import { computed } from '@vue/reactivity';

export const useExpensesStore = defineStore('expenses', () => {
    const expenses = ref<Expense[]>([]);

    const refreshAsync = async () => {
        await ApiService.getExpenses()
            .then(expenseCollection => {
                expenses.value = expenseCollection
            })
            .catch(error => console.error(error))
    }
    
    return {
        expenses,
        refreshAsync,
    };
});