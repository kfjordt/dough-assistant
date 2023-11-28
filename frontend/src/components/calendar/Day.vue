<template>
    <div class="day">
        <div class="add-expense-container">

        </div>
        <div class="flex flex-col">
            <span class="datelabel"> {{ props.day.getModel().getDate() }} </span>
            <div class="flex flex-col">
                <ExpenseCard v-for="(expense, idx) in expenses" :amount="expense.amount" :name="expense.name" :key="idx" />

            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { DateTime } from '../../models/common/DateTime';
import { PropType, ref } from 'vue';
import { computed } from '@vue/reactivity';
import { useExpensesStore } from '../../stores/expenses';
import { useStyleStore } from '../../stores/style';
import ExpenseCard from './ExpenseCard.vue';
import { useCalendarStore } from '../../stores/calendar';

const props = defineProps({
    day: {
        type: Object as PropType<DateTime>,
        required: true
    },
})


const expenses = [
    {
        amount: 20,
        name: "test"
    }, {
        amount: 20,
        name: "test2"
    },
]

const selectedMonth = useCalendarStore().selectedDate.getMonth()
const isPartOfCurrentMonth = computed(() => {
    return true
})

const style = useStyleStore().sectionStyles.calendar

const date = computed(() => props.day.getModel().getDate())
const dateLabelStyle = computed(() => {
    return DateTime.fromNow().sameDayAs(props.day)
        ? style.todayDateLabel
        : style.dateLabels
})

const expensesStore = useExpensesStore()
const availableExpenses = computed(() => expensesStore.expenses)

const eligibleExpenses = computed(() => {
    return availableExpenses.value
        .filter(expense => DateTime.fromUnix(expense.time).sameDayAs(props.day))
})

const handleAddExpense = () => {
    // ApiService.postNewExpense({
    //     name: expenseName.value,
    //     amount: expenseAmount.value,
    //     time: props.day.getModel()
    // }).catch(error => console.error(error))

    // expensesStore.refreshAsync()
}
</script>

<style scoped>
.day {
    display: flex;
    position: relative;
}

.datelabel {
    aspect-ratio: 1 / 1;
    border-radius: 4px;
    padding: 4px;
    height: 0.8rem;
    font-size: 0.8rem;
    display: flex;
    align-items: center;
    justify-content: center;
    position: relative;
    color: white;
    background-color: rgb(50, 50, 50);
    z-index: 100;
}

.add-expense-container {
    background-color: rgb(0, 0, 0);
    position: absolute;
    width: calc(100% - 8px);
    height: calc(100% - 8px);
    border-radius: 4px;
    margin: 4px;
}

.add-expense-container:hover {
    background-color: rgb(20, 20, 20);
}

.add-expense-container:active {
    background-color: rgb(40, 40, 40);
}
</style>