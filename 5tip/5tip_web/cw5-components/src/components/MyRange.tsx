
type Props = {
    label: string;
    min: number;
    max: number;    
    handleOnChange: (value: number) => void;
}

const MyRange = (props: Props) => {
  return (
    <div>
        <label>{props.label}</label>
        
    </div>
  )
}

export default MyRange  